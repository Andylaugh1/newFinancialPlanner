using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FinancialPlanner.API.Enums;
using FinancialPlanner.API.Models;

namespace FinancialPlanner.API.Helpers
{
    public class BankAccountFactory
    {
        public int? Id { get; set; }
        public string? AccountName { get; set; }
        public BankAccountType? AccountType { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public int? AccountNumber { get; set; }
        public int? SortCode { get; set; }
        public double? StartingBalance { get; set; }
        public double? CurrentBalance { get; set; }
        public int? AccountHolderId { get; set; }

        public BankAccountFactory()
        {
            
        }

        public BankAccountFactory(int? id, string? accountName, BankAccountType? accountType, int? accountNumber,
            int? sortCode, double? startingBalance, double? currentBalance, int? accountHolderId)
        {
            this.Id = id ?? id;
            this.AccountName = accountName ?? accountName;
            this.AccountType = accountType ?? accountType;
            this.AccountNumber = accountNumber ?? accountNumber;
            this.SortCode = sortCode ?? sortCode;
            this.StartingBalance = startingBalance ?? startingBalance;
            this.CurrentBalance = currentBalance ?? currentBalance;
            this.AccountHolderId = accountHolderId ?? accountHolderId;
        }

        public BankAccount GetNewBankAccount()
        {
            var newAccount = new BankAccount();

            newAccount.Id = this.Id.HasValue ? this.Id.Value : 1;
            newAccount.AccountName = !string.IsNullOrEmpty(this.AccountName) ? this.AccountName : "NewAccount1";
            newAccount.AccountType = this.AccountType.HasValue ? this.AccountType.Value : BankAccountType.IND_CURRENT_ACCOUNT;
            newAccount.AccountNumber = this.AccountNumber.HasValue ? this.AccountNumber.Value : 12345678;
            newAccount.SortCode = this.SortCode.HasValue ? this.SortCode.Value : 123456;
            newAccount.StartingBalance = this.StartingBalance.HasValue ? this.StartingBalance.Value : 100;
            newAccount.CurrentBalance = this.CurrentBalance.HasValue ? this.CurrentBalance.Value : newAccount.StartingBalance;
            newAccount.AccountHolderId = this.Id.HasValue ? this.Id.Value : 1;

            newAccount.Transactions = CreateNewTransactionsForAccount();

            return newAccount;
        }

        public BankAccount GetNewBankAccount(int? id, string? accountName, BankAccountType? accountType, int? accountNumber,
            int? sortCode, double? startingBalance, double? currentBalance, int? accountHolderId)
        {
            var newAccount = new BankAccount();
            
            newAccount.AccountName = !string.IsNullOrEmpty(accountName) ? accountName : "NewAccount1";
            newAccount.AccountType = accountType.HasValue ? accountType.Value : BankAccountType.IND_CURRENT_ACCOUNT;
            newAccount.AccountNumber = accountNumber.HasValue ? accountNumber.Value : 12345678;
            newAccount.SortCode = sortCode.HasValue ? sortCode.Value : 123456;
            newAccount.StartingBalance = startingBalance.HasValue ? startingBalance.Value : 100;
            newAccount.CurrentBalance = currentBalance.HasValue ? currentBalance.Value : newAccount.StartingBalance;
            newAccount.AccountHolderId = accountHolderId.HasValue ? accountHolderId.Value : 1;

            newAccount.Transactions = CreateNewTransactionsForAccount();

            return newAccount;
        }

        private List<Transaction> CreateNewTransactionsForAccount()
        {
            var transactions = new List<Transaction>();
            
            var transaction1 = new Transaction()
            {
                Value = 10.00,
                IsPositive = false,
                Name = "Withdrawal",
                Party = "Cashline",
                DateAndTime = DateTimeOffset.UtcNow
            };
            transactions.Add(transaction1);

            var transaction2 = new Transaction()
            {
                Value = 1000.00,
                IsPositive = true,
                Name = "Pay",
                Party = "Employer",
                DateAndTime = DateTimeOffset.UtcNow.AddDays(10)
            };
            transactions.Add(transaction2);

            return transactions;
        }
    }
}
using FinancialPlanner.API.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPlanner.API.Models
{
    public class BankAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AccountName { get; set; }
        public BankAccountType AccountType { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public int AccountNumber { get; set; }
        public int SortCode { get; set; }
        public double Balance { get; set; }

        [ForeignKey("AccountHolderId")]
        public virtual AccountHolder AccountHolder { get; set; }
        public int AccountHolderId { get; set; }

        public BankAccount()
        {
            this.Id = Id;
            this.AccountName = AccountName;
            this.AccountType = AccountType;
            this.Transactions = Transactions;
            this.AccountHolderId = AccountHolderId;
            this.AccountNumber = AccountNumber;
            this.SortCode = SortCode;
            this.Balance = Balance;
        }

        public List<int> GetAllTransactionIds()
        {
            var transactionIds = new List<int>();
            foreach (Transaction transaction in this.Transactions)
            {
                if (transaction.Id != null)
                {
                    transactionIds.Add(transaction.Id);
                }
            }

            return transactionIds;
        }

        public bool CheckForTransactionInAccount(Transaction requestedTransaction)
        {
            var requestedId = requestedTransaction.Id;
            foreach (Transaction transaction in this.Transactions)
            {
                if (transaction.Id == requestedId)
                {
                    return true;
                }
            }
            return false;
        }

        public Transaction GetTransactionById(int id)
        {
            foreach (Transaction transaction in this.Transactions)
            {
                if (transaction.Id == id)
                {
                    return transaction;
                }
            }
            return null;
        }

        public void AddNewTransactionToAccount(Transaction transaction)
        {
            this.Transactions.Add(transaction);
        }

        public void UpdateBalance(double amount)
        {
            double newBalance = this.Balance += amount;
            this.Balance = newBalance;
        }

        //Checks if the transaction is positive or negative and then calls the updateBalance and AddToAccountMethods
        public void ProcessTransactionOnAccount(Transaction transaction)
        {
            var transactionAmount = transaction.Value;
            var positiveOrNegativeAmount = 0.00;
            if (transaction.IsPositive == true)
            {
                positiveOrNegativeAmount = transactionAmount;
            }
            else
            {
                positiveOrNegativeAmount = (-transactionAmount);
            }

            this.UpdateBalance(positiveOrNegativeAmount);
            this.AddNewTransactionToAccount(transaction);
        }
    }
}

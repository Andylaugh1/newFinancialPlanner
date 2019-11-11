using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialPlanner.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialPlanner.API.Data_Access_Layer
{
    public class MainRepository : IMainRepository
    {
        private FinancialPlannerContext Context;

        public MainRepository(FinancialPlannerContext context)
        {
            this.Context = context;
        }

        // All transaction queries and commands
        public virtual IEnumerable<Transaction> GetAllTransactions()
        {
            return this.Context.Transactions.ToList();
        }

        public virtual Transaction GetTransactionById(int transactionId)
        {
            Transaction transaction;
            transaction = this.Context.Transactions.Where(t => t.Id == transactionId).FirstOrDefault();
            return transaction;
        }

        public virtual IEnumerable<Transaction> GetTransactionsForIdSet(IEnumerable<int> transactionIds)
        {
            var transactionsToReturn = new List<Transaction>();
            foreach(var transactionId in transactionIds)
            {
                transactionsToReturn.Add(this.Context.Transactions.Where(t => t.Id == transactionId).FirstOrDefault());
            }
            return transactionsToReturn;
        }
        
        // All Bank Account commands and queries
        
        public virtual IEnumerable<BankAccount> GetAllBankAccounts()
        {
            return this.Context.BankAccounts.ToList();
        }

        public virtual BankAccount GetBankAccountById(int bankAccountId)
        {
            BankAccount bankAccount;
            bankAccount = this.Context.BankAccounts.Where(t => t.Id == bankAccountId).FirstOrDefault();
            return bankAccount;
        }

        public virtual IEnumerable<BankAccount> GetBankAccountsForIdSet(IEnumerable<int> bankAccountIds)
        {
            var bankAccountsToReturn = new List<BankAccount>();
            foreach(var accountId in bankAccountIds)
            {
                bankAccountsToReturn.Add(this.Context.BankAccounts.Where(t => t.Id == accountId).FirstOrDefault());
            }
            return bankAccountsToReturn;
        }
    }
}

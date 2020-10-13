using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using FinancialPlanner.API.Models;
using Microsoft.EntityFrameworkCore;
using Transaction = FinancialPlanner.API.Models.Transaction;

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
            var transaction = this.Context.Transactions.FirstOrDefault(t => t.Id == transactionId);
            return transaction;
        }

        public virtual IEnumerable<Transaction> GetTransactionsForIdSet(IEnumerable<int> transactionIds)
        {
            var transactionsToReturn = new List<Transaction>();
            foreach(var transactionId in transactionIds)
            {
                transactionsToReturn.Add(this.Context.Transactions.FirstOrDefault(t => t.Id == transactionId));
            }
            return transactionsToReturn;
        }

        public void SaveTransactions(IEnumerable<Transaction> transactions)
        {
            using (var ts = new TransactionScope())
            {
                this.Context.AddRange(transactions);
                Context.SaveChanges();
                ts.Complete();
            }
            
        }
        
        // All Bank Account commands and queries
        
        public virtual IEnumerable<BankAccount> GetAllBankAccounts()
        {
            return this.Context.BankAccounts.ToList();
        }

        public virtual BankAccount GetBankAccountById(int bankAccountId)
        {
            var bankAccount = this.Context.BankAccounts.FirstOrDefault(t => t.Id == bankAccountId);
            return bankAccount;
        }

        public virtual IEnumerable<BankAccount> GetBankAccountsForIdSet(IEnumerable<int> bankAccountIds)
        {
            var bankAccountsToReturn = new List<BankAccount>();
            foreach(var accountId in bankAccountIds)
            {
                bankAccountsToReturn.Add(this.Context.BankAccounts.FirstOrDefault(t => t.Id == accountId));
            }
            return bankAccountsToReturn;
        }
        
        public void SaveUpdatedAccounts(IEnumerable<BankAccount> accounts)
        {
            using (var ts = new TransactionScope())
            {
                foreach (var account in accounts)
                {
                    var oldAccount = this.Context.BankAccounts.SingleOrDefault(ba => ba.Id == account.Id);
                    if (oldAccount != null)
                    {
                        oldAccount = account;
                        this.Context.BankAccounts.Update(oldAccount);
                    }
                }
                Context.SaveChanges();
                ts.Complete();
            }
        }
    }
}

using FinancialPlanner.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPlanner.API.Data_Access_Layer
{
    public interface IMainRepository
    {
       //Transaction commands and queries 
        IEnumerable<Transaction> GetAllTransactions();
        IEnumerable<Transaction> GetTransactionsForIdSet(IEnumerable<int> idSet);
        Transaction GetTransactionById(int id);
        
        // Bank Account commands and queries
        IEnumerable<BankAccount> GetAllBankAccounts();
        IEnumerable<BankAccount> GetBankAccountsForIdSet(IEnumerable<int> idSet);
        BankAccount GetBankAccountById(int id);
        
        // Account Holder commands and queries
        IEnumerable<AccountHolder> GetAllAccountHolders();
        IEnumerable<AccountHolder> GetAccountHoldersForIdSet(IEnumerable<int> idSet);
        AccountHolder GetAccountHolderById(int id);
    }
}

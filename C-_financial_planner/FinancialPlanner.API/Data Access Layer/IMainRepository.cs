using FinancialPlanner.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPlanner.API.Data_Access_Layer
{
    public interface IMainRepository
    {

        IEnumerable<Transaction> GetAllTransactions();
        IEnumerable<Transaction> GetTransactionsForIdSet(IEnumerable<int> idSet);
        Transaction GetTransactionById(int id);
    }
}

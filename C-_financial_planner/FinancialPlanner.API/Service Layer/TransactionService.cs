using FinancialPlanner.API.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialPlanner.API.Models;

namespace FinancialPlanner.API.Service_Layer
{
    public class TransactionService
    {
        public IMainRepository Repo { get; set; }

        public TransactionService(IMainRepository repo)
        {
            this.Repo = repo;
        }
        public IEnumerable<Transaction> GetAll()
        {
            return this.Repo.GetAllTransactions();
        }

        public Transaction GetById(int transactionId)
        {
            return this.Repo.GetTransactionById(transactionId);
        }

        public void CreateNewTransaction(string value)
        {
            
        }
     
    }
}

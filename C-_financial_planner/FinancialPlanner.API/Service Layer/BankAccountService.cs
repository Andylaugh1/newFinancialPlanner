using System.Collections.Generic;
using FinancialPlanner.API.Data_Access_Layer;
using FinancialPlanner.API.Models;

namespace FinancialPlanner.API.Service_Layer
{
    public class BankAccountService
    {
        public IMainRepository Repo { get; set; }

        public BankAccountService(IMainRepository repo)
        {
            this.Repo = repo;
        }
        public IEnumerable<BankAccount> GetAll()
        {
            return this.Repo.GetAllBankAccounts();
        }

        public BankAccount GetById(int bankAccountId)
        {
            return this.Repo.GetBankAccountById(bankAccountId);
        }

        public void CreateNewBankAccount(string value)
        {
            
        }
    }
}
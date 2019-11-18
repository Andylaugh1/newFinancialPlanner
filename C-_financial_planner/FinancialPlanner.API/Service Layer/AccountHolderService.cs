using System.Collections.Generic;
using FinancialPlanner.API.Data_Access_Layer;
using FinancialPlanner.API.Models;

namespace FinancialPlanner.API.Service_Layer
{
    public class AccountHolderService
    {
        public IMainRepository Repo { get; set; }

        public AccountHolderService(IMainRepository repo)
        {
            this.Repo = repo;
        }
        public IEnumerable<AccountHolder> GetAll()
        {
            return this.Repo.GetAllAccountHolders();
        }

        public AccountHolder GetById(int bankAccountId)
        {
            return this.Repo.GetAccountHolderById(bankAccountId);
        }

        public void CreateNewAccountHolder(string value)
        {
            
        }
    }
}
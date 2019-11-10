using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPlanner.API.Models
{
    public class StocksAndSharesAccountDto
    {
        public int id { get; set; }
        public string portfolioName { get; set; }
        public int portfolioHolderId { get; set; }
        public int accountNumber { get; set; }
        public double portfolioBalance { get; set; }

        public StocksAndSharesAccountDto(string portfolioName)
        {
            this.id = id;
            this.portfolioName = portfolioName;
            this.portfolioHolderId = portfolioHolderId;
            this.accountNumber = accountNumber;
            this.portfolioBalance = portfolioBalance;
        }
    }
}

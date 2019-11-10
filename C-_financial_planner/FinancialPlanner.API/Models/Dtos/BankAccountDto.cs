using FinancialPlanner.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPlanner.API.Models
{
    public class BankAccountDto
    {
        public int id { get; set; }
        public string accountName { get; set; }
        public BankAccountType accountType { get; set; }
        public List<TransactionDto> transactions { get; set; } = new List<TransactionDto>();
        public int accountHolderId { get; set; }
        public int accountNumber { get; set; }
        public int sortCode { get; set; }
        public double balance { get; set; }

        public BankAccountDto(string accountName, BankAccountType accountType)
        {
            this.id = id;
            this.accountName = accountName;
            this.accountType = accountType;
            this.transactions = transactions;
            this.accountHolderId = accountHolderId;
            this.accountNumber = accountNumber;
            this.sortCode = sortCode;
            this.balance = balance;
        }
    }
}

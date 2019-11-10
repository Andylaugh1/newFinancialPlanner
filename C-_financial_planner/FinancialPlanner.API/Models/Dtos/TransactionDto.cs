using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPlanner.API.Models
{
    public class TransactionDto
    {
        public int id { get; set; }
        public double value { get; set; }
        public bool isPositive { get; set; }
        public string name { get; set; }
        public string party { get; set; }

        public TransactionDto(double value, bool isPositive, string party)
        {
            this.id = id;
            this.value = value;
            this.isPositive = isPositive;
            this.name = name;
            this.party = party;
        }
    }
}

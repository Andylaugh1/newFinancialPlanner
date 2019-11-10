using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPlanner.API.Models
{
    public class AccountHolderDto
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }

        public AccountHolderDto(string firstName, string surname)
        {
            this.id = id;
            this.firstName = firstName;
            this.surname = surname;
        }
    }
}

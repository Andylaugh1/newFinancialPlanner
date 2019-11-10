using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPlanner.API.Models
{
    public class AccountHolder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public AccountHolder()
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.Surname = Surname;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPlanner.API.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double Value { get; set; }
        public bool IsPositive { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }

        [ForeignKey("BankAccountId")]
        public virtual BankAccount BankAccount { get; set; }
        public int BankAccountId { get; set; }

        public Transaction()
        {
            this.Id = Id;
            this.Value = Value;
            this.IsPositive = IsPositive;
            this.Name = Name;
            this.Party = Party;
        }
    }
}

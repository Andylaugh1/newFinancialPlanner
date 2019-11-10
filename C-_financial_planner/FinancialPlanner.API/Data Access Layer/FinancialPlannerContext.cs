using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using FinancialPlanner.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialPlanner.API.Data_Access_Layer
{
    public class FinancialPlannerContext : DbContext
    {

        public FinancialPlannerContext(DbContextOptions<FinancialPlannerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public FinancialPlannerContext()
        {
        }

        public DbSet<AccountHolder> AccountHolders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}

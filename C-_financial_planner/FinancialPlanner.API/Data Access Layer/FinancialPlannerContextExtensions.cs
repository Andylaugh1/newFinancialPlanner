using FinancialPlanner.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPlanner.API.Data_Access_Layer
{
    public static class FinancialPlannerContextExtensions
    {
        public static void EnsureSeedDataForContext(this FinancialPlannerContext context)
        {
            if (context.BankAccounts.Any())
            {
                return;
            }

            // init seed data
            var BankAccounts = new List<BankAccount>()
            {
                new BankAccount()
                {
                    Balance = 300.00,
                    AccountName = "Necessities Account",
                    AccountNumber = 12345678,
                    SortCode = 987654,
                    AccountType = Enums.BankAccountType.IND_CURRENT_ACCOUNT,
                    AccountHolderId = 1,
                    Transactions = new List<Transaction>()
                    {
                        new Transaction()
                        {
                            Value = 10.00,
                            IsPositive = false,
                            Name = "Withdrawal",
                            Party = "Cashline"
                        },
                        new Transaction()
                        {
                            Value = 300.00,
                            IsPositive = true,
                            Name = "Salary",
                            Party = "Work"
                        }

                    }
                },
                new BankAccount()
                {
                    Balance = 2000.00,
                    AccountName = "Savings",
                    AccountNumber = 13579753,
                    SortCode = 123412,
                    AccountType = Enums.BankAccountType.IND_SAVINGS_ACCOUNT,
                    AccountHolderId = 1,
                    Transactions = new List<Transaction>()
                    {
                        new Transaction()
                        {
                            Value = 200.00,
                            IsPositive = true,
                            Name = "Monthly Saving",
                            Party = "Andy Laughlin"
                        },
                        new Transaction()
                        {
                            Value = 100.00,
                            IsPositive = false,
                            Name = "Car Repairs",
                            Party = "KwikFit"
                        }

                    }
                }

            };
            var AccountHolders = new List<AccountHolder>()
            {
                new AccountHolder()
                {
                    FirstName = "Andy",
                    Surname = "Laughlin"
                }
            };

            context.BankAccounts.AddRange(BankAccounts);
            context.AccountHolders.AddRange(AccountHolders);
            context.SaveChanges();
        }
    }
}

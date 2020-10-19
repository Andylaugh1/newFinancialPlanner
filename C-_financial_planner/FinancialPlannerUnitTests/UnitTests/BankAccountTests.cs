using System;
using FinancialPlanner.API.Enums;
using FinancialPlanner.API.Helpers;
using FinancialPlanner.API.Models;
using FluentAssertions;
using Xunit;

namespace FinancialPlannerUnitTests
{
    public class BankAccountTests
    {
        [Fact]
        public void AbleToGetBankAccountProperties()
        {
            // Arrange
            var bankAccountFactory = new BankAccountFactory();
            var bankAccount1 = bankAccountFactory.GetNewBankAccount();

            var newAccountHolder = new AccountHolder()
            {
                Id = 2,
                FirstName = "John",
                Surname = "Bloggs"
            };
            var bankAccount2 = bankAccountFactory.GetNewBankAccount(2, "Andy Account",
                BankAccountType.IND_SAVINGS_ACCOUNT, 98765400, 345789, 20000.00, 25000.00, 2);

            // Act

            // Assert
            bankAccount1.Id.Should().Be(1);
            bankAccount2.AccountNumber.Should().Be(98765400);
        }

        [Fact]
        public void CanAddPositiveTransactionsToAccount_AndUpdateCurrentBalance()
        {
            // Arrange
            var bankAccountFactory = new BankAccountFactory();
            var bankAccount1 = bankAccountFactory.GetNewBankAccount();
            var transaction1 = new Transaction()
            {
                Value = 100.00,
                IsPositive = true,
                Name = "Pay",
                Party = "Employer",
                DateAndTime = DateTimeOffset.Now
            };

            // Act
            var currentAccountBalance = bankAccount1.CurrentBalance;
            var newCurrentBalanceShouldBe = currentAccountBalance + transaction1.Value;
            bankAccount1.ProcessTransactionOnAccount(transaction1);
            
            // Assert
            bankAccount1.CurrentBalance.Should().Be(newCurrentBalanceShouldBe);

        }
        
        [Fact]
        public void CanAddNegativeTransactionsToAccount_AndUpdateCurrentBalance()
        {
            // Arrange
            var bankAccountFactory = new BankAccountFactory();
            var bankAccount1 = bankAccountFactory.GetNewBankAccount();
            var transaction1 = new Transaction()
            {
                Value = 100.00,
                IsPositive = false,
                Name = "Shopping",
                Party = "Sainsbury",
                DateAndTime = DateTimeOffset.Now
            };

            // Act
            var currentAccountBalance = bankAccount1.CurrentBalance;
            var newCurrentBalanceShouldBe = currentAccountBalance - transaction1.Value;
            bankAccount1.ProcessTransactionOnAccount(transaction1);
            
            // Assert
            bankAccount1.CurrentBalance.Should().Be(newCurrentBalanceShouldBe);

        }

        [Fact]
        public void CanFindOutIfTransactionExistsOnAccount()
        {
            // Arrange
            var bankAccountFactory = new BankAccountFactory();
            var bankAccount1 = bankAccountFactory.GetNewBankAccount();
            var transaction1 = new Transaction()
            {
                Id = 3,
                Value = 100.00,
                IsPositive = false,
                Name = "Shopping",
                Party = "Sainsbury",
                DateAndTime = DateTimeOffset.Now
            };
            
            // Act
            bankAccount1.ProcessTransactionOnAccount(transaction1);
            var transactionFoundOnAccount = bankAccount1.CheckForTransactionInAccount(transaction1);

            // Assert
            transactionFoundOnAccount.Should().BeTrue();
        }
        
        [Fact]
        public void CanGetTransactionByIdFromBankAccount()
        {
            // Arrange
            var bankAccountFactory = new BankAccountFactory();
            var bankAccount1 = bankAccountFactory.GetNewBankAccount();
            var transaction1 = new Transaction()
            {
                Id = 3,
                Value = 100.00,
                IsPositive = false,
                Name = "Shopping",
                Party = "Sainsbury",
                DateAndTime = DateTimeOffset.Now
            };
            
            // Act
            bankAccount1.ProcessTransactionOnAccount(transaction1);
            var transaction = bankAccount1.GetTransactionById(transaction1.Id);

            // Assert
            transaction.Id.Should().Be(3);
            transaction.Value.Should().Be(100);
            transaction.IsPositive.Should().BeFalse();
            transaction.Name.Should().Be("Shopping");
            transaction.Party.Should().Be("Sainsbury");
        }
    }
}
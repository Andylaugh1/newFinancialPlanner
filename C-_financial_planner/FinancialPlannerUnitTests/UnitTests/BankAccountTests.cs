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
        public void CanAddPositiveTransactionsToAccountAndUpdateCurrentBalance()
        {
            // Arrange
            var bankAccountFactory = new BankAccountFactory();
            var bankAccount1 = bankAccountFactory.GetNewBankAccount();
        }
    }
}
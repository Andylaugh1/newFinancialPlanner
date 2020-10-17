using System;
using Xunit;
using FluentAssertions;
using FinancialPlanner.API.Models;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;

namespace FinancialPlannerUnitTests
{
    public class TransactionTests
    {
        [Fact]
        public void AbleToGetTransactionProperties()
        {
            // Arrange
            var transaction = new Transaction()
                {
                    Value = 10.00,
                    IsPositive = false,
                    Name = "Withdrawal",
                    Party = "Cashline",
                    DateAndTime = DateTimeOffset.Now
                };
            
            // Act
            var transactionValue = transaction.Value;
            var transactionPositive = transaction.IsPositive;
            var transactionName = transaction.Name;
            var transactionParty = transaction.Party;
            var transactionDateAndTime = transaction.DateAndTime;
            var testDateAndTime = new DateTimeOffset(2020, 10, 15, 23, 0, 0, new TimeSpan());

            // Assert
            transactionValue.Should().Be(10.00);
            transactionPositive.Should().Be(false);
            transactionName.Should().Be("Withdrawal");
            transactionParty.Should().Be("Cashline");
            transactionDateAndTime.Should().BeAfter(testDateAndTime);

        }
    }
}
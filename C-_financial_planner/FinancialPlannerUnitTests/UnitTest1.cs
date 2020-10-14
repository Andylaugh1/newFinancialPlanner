using System;
using Xunit;
using FluentAssertions;
using FinancialPlanner.API.Models;
using FluentAssertions.Common;

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
            var expectedResult = 10.00;

            // Assert
            transactionValue.IsSameOrEqualTo(expectedResult);

        }
    }
}
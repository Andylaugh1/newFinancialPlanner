using FinancialPlanner.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialPlannerTests
{
    [TestClass]
    public class AccountHolderTest
    {
        AccountHolder accountHolder1;

        [TestInitialize]
        public void initialize()
        {
            accountHolder1 = new AccountHolder();
            accountHolder1.Id = 10;
            accountHolder1.FirstName = "Andy";
            accountHolder1.Surname = "Laughlin";
        }

        [TestMethod]
        public void CanGetAccountHolderProperties()
        {
            Assert.AreEqual("Andy", accountHolder1.FirstName);
            Assert.AreEqual("Laughlin", accountHolder1.Surname);
            Assert.AreEqual(10, accountHolder1.Id);
        }
    }
}

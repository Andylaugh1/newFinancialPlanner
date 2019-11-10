using FinancialPlanner.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialPlannerTests
{
    [TestClass]
    public class TransactionTest
    {
        private Transaction transaction1;

        [TestInitialize]
        public void Init()
        {
            transaction1 = new Transaction();
            transaction1.Name = "Amazon Order";
            transaction1.Value = 24.99;
            transaction1.IsPositive = true;
            transaction1.Party = "Amazon";
        }

        [TestMethod]
        public void CanGetTransactionValueProperties()
        {
            Assert.AreEqual(24.99, transaction1.Value);
            Assert.AreEqual(true, transaction1.IsPositive);
            Assert.AreEqual("Amazon Order", transaction1.Name);
            Assert.AreEqual("Amazon", transaction1.Party);
        }
    }
}

using FinancialPlanner.API.Enums;
using FinancialPlanner.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialPlannerTests
{
    [TestClass]
    public class BankAccountTest
    {
        BankAccount testAccount;
        Transaction testTransaction1;
        Transaction testTransaction2;
        AccountHolder testAccountHolder1;

        [TestInitialize]
        public void Initialize()
        {
            testTransaction1 = new Transaction();
            testTransaction2 = new Transaction();
            testTransaction1.Id = 1;
            testTransaction1.Value = 24.99;
            testTransaction1.IsPositive = true;
            testTransaction1.Party = "Amazon";
            testTransaction2.Id = 2;
            testTransaction2.Value = 20.00;
            testTransaction2.IsPositive = true;
            testTransaction2.Party = "Work";

            testAccountHolder1 = new AccountHolder();
            testAccountHolder1.Id = 12;
            testAccountHolder1.FirstName = "Andy";
            testAccountHolder1.Surname = "Laughlin";

            testAccount = new BankAccount();
            testAccount.AccountHolderId = testAccountHolder1.Id;
            testAccount.AccountNumber = 12345678;
            testAccount.SortCode = 123456;
            testAccount.Transactions.Add(testTransaction1);
            testAccount.Transactions.Add(testTransaction2);
            testAccount.Balance = 100.00;
            testAccount.AccountName = "Andy Current Account";
            testAccount.AccountType = BankAccountType.IND_CURRENT_ACCOUNT;
        }
        

        [TestMethod]
        public void CanGetBankAccountProperties()
        { 
            Assert.AreEqual("Andy Current Account", testAccount.AccountName);
            Assert.AreEqual(12345678, testAccount.AccountNumber);
            Assert.AreEqual(BankAccountType.IND_CURRENT_ACCOUNT, testAccount.AccountType);
            Assert.AreEqual(123456, testAccount.SortCode);
            Assert.AreEqual(100.00, testAccount.Balance);
        }

        [TestMethod]
        public void CanGetBankAccountTransactionIds()
        {
            var transactionIds = new List<int>();
            transactionIds = testAccount.GetAllTransactionIds();
            var result = transactionIds.Count;
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CanCheckIfTransactionIsInThisAccount_true()
        {
            var result = testAccount.CheckForTransactionInAccount(testTransaction1);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CanGetTransactionById_transactionPresent()
        {
            var returnedTransaction = testAccount.GetTransactionById(testTransaction1.Id);
            var result = returnedTransaction.Id;
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CanUpdateBalanceFollowingTransaction()
        {
            var amount = testTransaction1.Value;
            testAccount.UpdateBalance(amount);
            Assert.AreEqual(124.99, testAccount.Balance);
        }

        [TestMethod]
        public void CanProcessTransactionWhen_TransactionPositive()
        {
            var testTransaction3 = new Transaction();
            testTransaction3.Id = 3;
            testTransaction3.Value = 20.00;
            testTransaction3.IsPositive = true;
            testTransaction3.Party = "Work";
            testAccount.ProcessTransactionOnAccount(testTransaction3);

            var result1 = testAccount.GetTransactionById(testTransaction3.Id);
            var result2 = testAccount.Balance;

            Assert.AreEqual(3, result1.Id);
            Assert.AreEqual(120.00, result2);
        }

        [TestMethod]
        public void CanProcessTransactionWhen_TransactionNegative()
        {
            var testTransaction3 = new Transaction();
            testTransaction3.Id = 3;
            testTransaction3.Value = 20.00;
            testTransaction3.IsPositive = false;
            testTransaction3.Party = "Work";
            testAccount.ProcessTransactionOnAccount(testTransaction3);

            var result1 = testAccount.GetTransactionById(testTransaction3.Id);
            var result2 = testAccount.Balance;

            Assert.AreEqual(3, result1.Id);
            Assert.AreEqual(80.00, result2);
        }
    }
}

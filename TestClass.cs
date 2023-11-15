using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLab
{
    [TestClass]
    public class BankUnitTest
    {
        [TestMethod]
        public void TestDeposit()
        {
            BankAccount a1 = new BankAccount("AIB2kI3", "x9223T");
            a1.Deposit(100);
            a1.Deposit(100);
            Assert.AreEqual(a1.Balance, 200);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDepositException() 
        {
            BankAccount a1 = new BankAccount("AIB2kI3", "x9223T", 100, 200);
            a1.Deposit(-100);
            
        }


        [TestMethod]
        public void TestWidrawal()
        {
            BankAccount a1 = new BankAccount("AIB2kI3", "x9223T");
            a1.Withdraw(100);
            a1.Withdraw(20);
            Assert.AreEqual(a1.Balance, 80);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException))]
        public void TestWidrawalException()
        {
            BankAccount a1 = new BankAccount("AIB2kI3", "x9223T", 200, 500);
            a1.Withdraw(6000);
        }

        [TestMethod]
        public void TestHistory()
        {
            BankAccount a1 = new BankAccount("AIB2kI3", "x9223T");
            a1.Deposit(2000);
            a1.Withdraw(1000);
            a1.Withdraw(20);
            a1.Deposit(75);
            a1.Withdraw(10);
            Assert.AreEqual(a1.Balance, 1045);
            CollectionAssert.AreEqual(a1.History, new List<double>() { 2000, -1000, 20, 75, 10 });
        }

        [TestMethod]
        public void TestAccountHistory()
        {
            BankAccount a1 = new BankAccount("AIB2kI3", "x9223T", 0, 0);
            Assert.AreEqual(a1.Balance, 0);
            CollectionAssert.AreEqual(a1.History, new List<double>() { 0 });
        }
    }

}

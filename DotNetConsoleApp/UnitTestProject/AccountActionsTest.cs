using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetConsoleApp;

namespace UnitTestProject
{
    [TestClass]
    public class AccountActionsTests
    {
        [TestMethod]
        public void DepositNegativeAmountReturnsFalse()
        {
            Account account = new Account() { number = "00001234", balance = 999.0 };

            AccountActions actions = new AccountActions();

            Assert.IsFalse(actions.Deposit(account, -10.05));
        }

        [TestMethod]
        public void DepositNoAccountNumberReturnsFalse()
        {
            Account account = new Account() { number = null, balance = 999.0 };

            AccountActions actions = new AccountActions();

            Assert.IsFalse(actions.Deposit(account, 10.05));
        }

        [TestMethod]
        public void DepositPositiveAmountReturnsTrue()
        {
            Account account = new Account() { number = "00001234", balance = 999.0 };

            AccountActions actions = new AccountActions();

            Assert.IsTrue(actions.Deposit(account, 10.05));
        }

        [TestMethod]
        public void DepositPositiveAmountBalanceUpdated()
        {
            Account account = new Account() { number = "00001234", balance = 999.0 };

            AccountActions actions = new AccountActions();

            actions.Deposit(account, 10.05);

            Assert.AreEqual(999.0 + 10.05, account.balance);
        }

        [TestMethod]
        public void WithdrawNegativeAmountReturnsFalse()
        {
            Account account = new Account() { number = "00001234", balance = 999.0 };

            AccountActions actions = new AccountActions();

            Assert.IsFalse(actions.Withdraw(account, -10.05));
        }

        [TestMethod]
        public void WithdrawNoAccountNumberReturnsFalse()
        {
            Account account = new Account() { number = null, balance = 999.0 };

            AccountActions actions = new AccountActions();

            Assert.IsFalse(actions.Withdraw(account, 10.05));
        }

        [TestMethod]
        public void WithdrawPositiveAmountReturnsTrue()
        {
            Account account = new Account() { number = "00001234", balance = 999.0 };

            AccountActions actions = new AccountActions();

            Assert.IsTrue(actions.Withdraw(account, 10.05));
        }

        [TestMethod]
        public void WithdrawPositiveAmountBalanceUpdated()
        {
            Account account = new Account() { number = "00001234", balance = 999.0 };

            AccountActions actions = new AccountActions();

            actions.Withdraw(account, 10.05);

            Assert.AreEqual(999.0 - 10.05, account.balance);
        }

        [TestMethod]
        public void WithdrawOverdrawnReturnsFalse()
        {
            Account account = new Account() { number = "00001234", balance = 9.0 };

            AccountActions actions = new AccountActions();

            actions.Withdraw(account, 10.05);

            Assert.IsFalse(actions.Withdraw(account, 10.05));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetConsoleApp;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class AccountActionsTests
    {
        [TestMethod]
        public void DepositNegativeAmountReturnsFalse()
        {
            var account = new Mock<IAccount>();   
            account.Setup(x => x.balance).Returns(999.00);
            account.Setup(x => x.number).Returns("00001234");

            AccountActions actions = new AccountActions();

            Assert.IsFalse(actions.Deposit(account.Object, -10.05));
        }

        [TestMethod]
        public void DepositNoAccountNumberReturnsFalse()
        {
            var account = new Mock<IAccount>();
            account.Setup(x => x.balance).Returns(999.0);

            AccountActions actions = new AccountActions();

            Assert.IsFalse(actions.Deposit(account.Object, 10.05));
        }

        [TestMethod]
        public void DepositPositiveAmountReturnsTrue()
        {
            var account = new Mock<IAccount>();
            account.Setup(x => x.balance).Returns(999.00);
            account.Setup(x => x.number).Returns("00001234");

            AccountActions actions = new AccountActions();

            Assert.IsTrue(actions.Deposit(account.Object, 10.05));
        }

        [TestMethod]
        public void DepositPositiveAmountBalanceUpdated()
        {
            var account = new Mock<IAccount>();
            account.SetupProperty(x => x.balance);
            account.Object.balance = 999.00;
            account.Setup(x => x.number).Returns("00001234");

            AccountActions actions = new AccountActions();

            actions.Deposit(account.Object, 10.05);

            Assert.AreEqual(999.0 + 10.05, account.Object.balance);
        }

        [TestMethod]
        public void WithdrawNegativeAmountReturnsFalse()
        {
            var account = new Mock<IAccount>();
            account.Setup(x => x.balance).Returns(999.00);
            account.Setup(x => x.number).Returns("00001234");

            AccountActions actions = new AccountActions();

            Assert.IsFalse(actions.Withdraw(account.Object, -10.05));
        }

        [TestMethod]
        public void WithdrawNoAccountNumberReturnsFalse()
        {
            var account = new Mock<IAccount>();
            account.Setup(x => x.balance).Returns(999.00);

            AccountActions actions = new AccountActions();

            Assert.IsFalse(actions.Withdraw(account.Object, 10.05));
        }

        [TestMethod]
        public void WithdrawPositiveAmountReturnsTrue()
        {
            var account = new Mock<IAccount>();
            account.Setup(x => x.balance).Returns(999.00);
            account.Setup(x => x.number).Returns("00001234");

            AccountActions actions = new AccountActions();

            Assert.IsTrue(actions.Withdraw(account.Object, 10.05));
        }

        [TestMethod]
        public void WithdrawPositiveAmountBalanceUpdated()
        {
            var account = new Mock<IAccount>();
            account.SetupProperty(x => x.balance);
            account.Object.balance = 999.00;
            account.Setup(x => x.number).Returns("00001234");

            AccountActions actions = new AccountActions();

            actions.Withdraw(account.Object, 10.05);

            Assert.AreEqual(999.0 - 10.05, account.Object.balance);
        }

        [TestMethod]
        public void WithdrawOverdrawnReturnsFalse()
        {
            var account = new Mock<IAccount>();
            account.Setup(x => x.balance).Returns(9.00);
            account.Setup(x => x.number).Returns("00001234");

            AccountActions actions = new AccountActions();

            actions.Withdraw(account.Object, 10.05);

            Assert.IsFalse(actions.Withdraw(account.Object, 10.05));
        }

        [TestMethod]
        public void TestLoggerWasCalled()
        {
            //Constructor injection
            var account = new Mock<IAccount>();
            account.Setup(x => x.balance).Returns(9.00);
            account.Setup(x => x.number).Returns("00001234");

            var logger = new Mock<ILogger>();
            logger.Object.isAdmin = true;
            logger.Object.file = @"c:\log\error.log";

            AccountActions actions = new AccountActions(logger.Object);

            actions.Withdraw(account.Object, 10.05);

            logger.Verify(x => x.log(It.IsAny<string>()), Times.Once);
        }
    }
}

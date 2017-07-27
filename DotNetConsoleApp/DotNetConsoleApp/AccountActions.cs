using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetConsoleApp
{
    public class AccountActions
    {
        Logger logger;

        public AccountActions() { }

        public AccountActions(Logger logger)
        {
            this.logger = logger;
        }

        public bool Deposit(IAccount account, double amount)
        {
            if (amount <= 0) { return false; }
            if (String.IsNullOrEmpty(account.number)) { return false; }

            account.balance += amount;

            return true;
        }

        public bool Withdraw(IAccount account, double amount)
        {
            if (amount <= 0) { return false; }
            if (String.IsNullOrEmpty(account.number)) { return false; }
            if (account.balance < amount) { return false; }

            account.balance -= amount;

            return true;
        }
    }
}

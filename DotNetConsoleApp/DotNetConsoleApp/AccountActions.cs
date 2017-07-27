using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetConsoleApp
{
    public class AccountActions
    {
        ILogger logger;

        public AccountActions() { }

        public AccountActions(ILogger logger)
        {
            this.logger = logger;
        }

        public bool Deposit(IAccount account, double amount)
        {
            if (amount <= 0)
            {
                if (logger != null) { logger.log("Deposit amount must be positive"); }

                return false;
            }

            if (String.IsNullOrEmpty(account.number))
            {
                if (logger != null) { logger.log("Account is blank"); }

                return false;
            }

            account.balance += amount;

            return true;
        }

        public bool Withdraw(IAccount account, double amount)
        {
            if (amount <= 0)
            {
                if (logger != null) { logger.log("Withdrawl amount must be positive"); }

                return false;
            }

            if (String.IsNullOrEmpty(account.number))
            {
                if (logger != null) { logger.log("Account is blank"); }

                return false;
            }

            if (account.balance < amount)
            {
                if (logger != null) { logger.log("Not enough money"); }

                return false;
            }

            account.balance -= amount;

            return true;
        }
    }
}

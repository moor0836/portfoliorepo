using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankApplication.Data
{
    public class BankAccount
    {
        static List<int> usedAccountNumbers = new List<int>();
        private readonly string accountNumber;
        private decimal _accountBalance;
        private string _accountOwner;
        private readonly DateTime created;
        Random rng = new Random();

        public BankAccount(string accountNum, string name, decimal balance, DateTime set) //a (accountnumber, string), b name(string) c (balance, decimal), d (created, datetime)
        {
            accountNumber = accountNum;
            _accountOwner = name;
            _accountBalance = balance;
            created = set;
        }

        public BankAccount(string name)
        {
            while (true)
            {
                int potentialNumber = rng.Next(0, 1000000);
                if (!usedAccountNumbers.Contains(potentialNumber))
                {
                    accountNumber = $"{potentialNumber:000000}";
                    created = DateTime.Now;
                    usedAccountNumbers.Add(potentialNumber);
                    break;
                }
            }
            _accountOwner = name;
           
        }

        public BankAccount(string name, decimal balance)
        {
            while (true)
            {
                int potentialNumber = rng.Next(0, 1000000);
                if (!usedAccountNumbers.Contains(potentialNumber))
                {
                    accountNumber = $"{potentialNumber:000000}";
                    created = DateTime.Now;
                    usedAccountNumbers.Add(potentialNumber);
                    break;
                }
            }
            _accountOwner = name;
            _accountBalance = balance;
        }

        public bool WithdrawOrDeposit(decimal amount)
        {
            bool result = false;
            if (_accountBalance + amount >= 0)
            {
                _accountBalance += amount;
                result = true;
            }
            return result;
        }
        public bool UpdateOwner(string name)
        {
            bool success = false;
            if (name != "")
            {
                _accountOwner = name;
                success = true;
            }
            return success;
        }
        public string RetrieveAccountNumber()
        {
            return accountNumber;
        }
        public string RetrieveOwnerName()
        {
            return _accountOwner;
        }
        public string RetrieveAccountBalance()
        {
            string result = $"$ {_accountBalance}";
            return result;
        }
        public decimal RetrieveAccountBalanceDecimal()
        {
            return _accountBalance;
        }
        public DateTime Created()
        {
            return created;
        }

    }

}

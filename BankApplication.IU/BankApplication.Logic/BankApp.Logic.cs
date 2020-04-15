using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Data;

namespace BankApplication.Logic
{
    public class LogicValidation
    {
        DatabaseOfAccounts obj = new DatabaseOfAccounts();
        public bool Add(string name)
        {
            bool success = false;
            if (name != "")
            {
                obj.Add(name);
                success = true;
            }
            return success;
        }
        public bool Add(string name, decimal balance)
        {
            bool success = false;
            if (name != "" && balance>= 0)
            {
                obj.Add(name, (balance + Math.Min(balance, 500)));
                success = true;
            }
            return success;
        }
        public int Remove(string ToRemove)
        {
            return obj.Remove(ToRemove);
        }
        public bool UpdateName(string accountNumber, string newName)
        {
            return obj.UpdateName(accountNumber, newName);
        }
        public bool WithdrawOrDeposit(string accountNumber, decimal amount)
        {
            return obj.WithdrawOrDeposit(accountNumber, amount);
        }
        public List<BankAccount> RetrieveSingle(string input)
        {
            return obj.RetrieveSingle(input);
        }
        public List<BankAccount> RetrieveAll ()
        {
            return obj.RetrieveAll();
        }
        public List<BankAccount> GetAccountsWithBalance (decimal balance)
        {
            List<BankAccount> allAccounts = obj.RetrieveAll();
            return allAccounts.Where(x => x.RetrieveAccountBalanceDecimal() >= balance).ToList();
            /*List<BankAccount> allAccounts = obj.RetrieveAll();
            List<BankAccount> result = new List<BankAccount>();
            foreach(BankAccount x in allAccounts)
            {
                if (x.RetrieveAccountBalanceDecimal() >= balance)
                    result.Add(x);
            }
            return result;*/
        }
    }
}

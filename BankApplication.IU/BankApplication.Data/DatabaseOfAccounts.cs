using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankApplication.Data
{
    public class DatabaseOfAccounts
    {
        private List<BankAccount> database = new List<BankAccount>();//= new List<BankAccount>() { new BankAccount("test1", 500), new BankAccount("test2"), new BankAccount("test3", 10000) };
        string path = @".\bankaccountlist.txt";



        public string MapAccountToLine(BankAccount x)
        {
            return x.RetrieveAccountNumber() + "|" + x.RetrieveOwnerName() + "|" + x.RetrieveAccountBalanceDecimal() + "|" + x.Created();
        }
        public void WriteAllAccounts()
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (BankAccount x in database)
                {
                    writer.WriteLine(MapAccountToLine(x)); // acctnumber::owner::acctbalance::created;
                }
            }
        }
        private void SetUp()
        {
                string[] allLines = File.ReadAllLines(path); // returns an array of strings comprised of acctnumber::owner::acctbalance::created;
                database = new List<BankAccount>();
                foreach (string line in allLines)
                    AddFromFile(line);
        }
        private void AddFromFile(string line)
        {
            string a, b;
            decimal c;
            DateTime d;
            //parse line into parts a (accountnumber, string), b name(string) c (balance, decimal), d (created, datetime)
            string[] separated = line.Split('|');
            a = separated[0];
            b = separated[1];
            c = System.Convert.ToDecimal(separated[2]);
            d = DateTime.Parse(separated[3]);
            database.Add(new BankAccount(a, b, c, d));
        }

        public void Add(string name)
        {
            SetUp();
            BankAccount adding = new BankAccount(name);
            database.Add(adding);
            WriteAllAccounts();
        }
        public void Add(string name, decimal balance)
        {
            SetUp();
            BankAccount adding = new BankAccount(name, balance);
            database.Add(adding);
            WriteAllAccounts();
        }
        public int Remove(string ToRemove)
        {
            SetUp();
            int result = database.RemoveAll(x => x.RetrieveAccountNumber() == ToRemove || x.RetrieveOwnerName() == ToRemove);
            WriteAllAccounts();
            return result;
        }
        public bool UpdateName(string accountNumber, string newName)
        {
            SetUp();
            bool success = false;
            foreach (BankAccount x in database)
            {
                if (x.RetrieveAccountNumber() == accountNumber && x.UpdateOwner(newName))
                {
                    success = true;
                    break;
                }
            }
            WriteAllAccounts();
            return success;
        }
        public bool WithdrawOrDeposit(string accountNumber, decimal amount)
        {
            SetUp();
            bool success = false;
            foreach (BankAccount x in database)
            {
                if ((x.RetrieveAccountNumber() == accountNumber) && x.WithdrawOrDeposit(amount))
                {
                    success = true;
                    break;
                }
            }
            WriteAllAccounts();
            return success;

        }
        public List<BankAccount> RetrieveSingle(string input)//can input name or account number
        {
            SetUp();
            return database.Where(x => (x.RetrieveOwnerName() == input || x.RetrieveAccountNumber() == input)).ToList();
        }
        public List<BankAccount> RetrieveAll()
        {
            SetUp();
            return database;
        }
    }
}

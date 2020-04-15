using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Logic;
using BankApplication.Data;
using NUnit.Framework;

namespace BankApplication.Tests
{
    [TestFixture]
    public class Tests
    {
        static LogicValidation obj = new LogicValidation();

        [SetUp]
        public void Reset()
        {
            obj = new LogicValidation(); //{ new BankAccount("test1", 500), new BankAccount("test2"), new BankAccount("test3", 10000) };
        }

    [TestCase("", false)]
        [TestCase("Miriam", true)]
        [TestCase("j", true)]
        public void AddNameOnly(string input, bool expected)
        {
            bool actual = obj.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Mine", 0, true)]
        [TestCase("Mine", -100, false)]
        [TestCase("", 500, false)]
        [TestCase("Miriam", 500, true)]
        public void AddNameAndInitialBalance(string name, int deposit, bool expected)
        {
            bool actual = obj.Add(name, deposit);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("test2", 1)]
        [TestCase("Miriam", 0)]
        public void Remove1(string remove, int expected)
        {
            int actual = obj.Remove(remove);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Remove2()
        {
            int actual = obj.Remove(obj.RetrieveSingle("test3")[0].RetrieveAccountNumber());
            Assert.AreEqual(actual, 1);
        }

        [Test]
        public void WithdrawOrDeposit()
        {
            bool result = obj.WithdrawOrDeposit(obj.RetrieveSingle("test1")[0].RetrieveAccountNumber(), -1000);
            Assert.AreEqual(result, false);
            bool result2 = obj.WithdrawOrDeposit(obj.RetrieveSingle("test1")[0].RetrieveAccountNumber(), -100);
            Assert.AreEqual(result2, true); //now at 400
            bool result3 = obj.WithdrawOrDeposit(obj.RetrieveSingle("test1")[0].RetrieveAccountNumber(), 1000);
            Assert.AreEqual(result3, true);
        }
    }
}

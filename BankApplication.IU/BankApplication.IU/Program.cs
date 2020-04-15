using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Data;
using BankApplication.Logic;
using System.IO;

namespace BankApplication.IU
{
    class Program
    {
        static LogicValidation obj = new LogicValidation();
        static void Menu()
        {
            Console.Clear();
            int result;
            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1 - Display account");
                Console.WriteLine("2 - Withdraw");
                Console.WriteLine("3 - Deposit");
                Console.WriteLine("4 - Create Account");
                Console.WriteLine("5 - Display Lists of Accounts over a certain balance");
                Console.WriteLine("6 - Quit");
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    if (1 <= result && result <= 5)
                        break;
                    else
                    {

                        Console.WriteLine("That doesn't appear to be a valid option.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("I didn't get that. Press enter to try again.");
                    Console.ReadLine();
                    Console.Clear();
                }
                Console.ReadLine();

            }
            switch (result)
            {
                case 1:
                    DisplayAccount();
                    Console.ReadLine();
                    break;
                case 2:
                    Withdraw();
                    Console.ReadLine();
                    break;
                case 3:
                    Deposit();
                    Console.ReadLine();
                    break;
                case 4:
                    CreateAccount();
                    Console.ReadLine();
                    break;
                case 5:
                    ListAccountsBalanceOver();
                    break;
                case 6:
                    return;
            }
            Menu();
        }
        static bool GetBoolFromUser(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine().ToLower();
                if (input == "y" || input == "yes")
                    return true;
                else if (input == "n" || input == "no")
                    return false;
                else
                    Console.WriteLine("I didn't get that. Let's try again.");
            }
        }
        static void DisplayAccount()
        {
            bool all = GetBoolFromUser("Do you want to display all of the accounts in the database?");
            if (all)
            {
                try
                {
                    DisplayListOfAccounts(obj.RetrieveAll());
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("That file was not found.");
                }
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Please enter the owner name or full six digit account number. Enter q to quit.");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "q")
                        return;
                    List<BankAccount> result = new List<BankAccount>();
                    try
                    {
                        result = obj.RetrieveSingle(input);
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("FileNotFound");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("There was an unknown error.");
                    }
                    if (result.Count != 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Match(es):");
                        DisplayListOfAccounts(result);
                        return;
                    }
                    else
                        Console.WriteLine("That didn't return any results. Try again.");
                }
            }
        }
        static void DisplayListOfAccounts(List<BankAccount> list)
        {
            foreach (BankAccount x in list)
            {
                Console.WriteLine("Account Number: " + x.RetrieveAccountNumber());
                Console.WriteLine("Account Owner: " + x.RetrieveOwnerName());
                Console.WriteLine("Account Balance: " + x.RetrieveAccountBalance());
                Console.WriteLine("Customer since: " + x.Created());
                Console.WriteLine();
            }
        }
        static void Withdraw()
        {
            Console.WriteLine();
            string account = GetAccountNumberFromUser();
            decimal amount = GetDecimalFromUser("How much would you like to withdraw?");
            bool success = true;
            try
            {
                success = obj.WithdrawOrDeposit(account, -amount);
            }
            catch (Exception)
            {
                Console.WriteLine("There was an unknown exception.");
            }
            if (success == true)
                Console.WriteLine("The withdrawal was successful.");
            else
                Console.WriteLine("There were insufficient funds to complete the withdrawal.");
        }
        static void Deposit()
        {
            Console.WriteLine();
            string account = GetAccountNumberFromUser();
            decimal amount = GetDecimalFromUser("How much would you like to deposit?");
            bool success = obj.WithdrawOrDeposit(account, amount);
            if (success == true)
                Console.WriteLine("The deposit was successful.");
            else
                Console.WriteLine("Something went wrong and the withdrawal was not completed.");
        }
        static string GetAccountNumberFromUser() // get an active account number. continue prompting until you find an active account number.
        {
            string result;
            while (true)
            {
                Console.WriteLine("What is the full 6 digit account number? Press q to quit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                    Menu();
                if (obj.RetrieveSingle(input).Count() == 0)
                    Console.WriteLine("That didn't pull up an account. Try again.");
                else
                {
                    result = input;
                    break;
                }
            }
            return result;
        }
        static decimal GetDecimalFromUser(string prompt)
        {
            decimal result;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out result))
                {
                    break;
                }
                else
                    Console.WriteLine("I didn't get that. Try again.");
            }
            return result;
        }
        static void CreateAccount()
        {
            string name = "void";
            while (true)
            {
                Console.WriteLine("What is the owner's name?");
                string input = Console.ReadLine();
                if (input != "")
                {
                    bool appropriateName = true;
                    for (int i = 0; i < input.Length; i++)
                        if ("0123456789".Contains(input[i]))
                        {
                            Console.WriteLine("The name must not contain numbers.");
                            appropriateName = false;
                            break;
                        }
                    if (appropriateName)
                    {
                        name = input;
                        break;
                    }
                }
                else
                    Console.WriteLine("I didn't get that. Try again.");
                if (name != "void")
                    break;
            }
            bool money = GetBoolFromUser("Would you like to make an initial deposit?");
            if (money == true)
            {
                decimal amount = GetDecimalFromUser("How much would you like to deposit?");
                obj.Add(name, amount);
            }
            else
                obj.Add(name);
        }

        static void ListAccountsBalanceOver()
        {
            decimal amount = GetDecimalFromUser("What is the minimum balance?");
            List<BankAccount> result = obj.GetAccountsWithBalance(amount);
            DisplayListOfAccounts(result);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            try
            {
                Menu();
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("The file could not be found.");
                Console.ReadLine();
            }
            catch(FormatException)
            {
                Console.WriteLine("There is a formatting error in the file.");
                Console.ReadLine();
            }
            catch(Exception)
            {
                Console.WriteLine("There was an unknown exception.");
            }

        }
    }
}

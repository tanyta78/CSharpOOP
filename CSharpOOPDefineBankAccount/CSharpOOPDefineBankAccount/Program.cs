using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string input;
        var accounts = new Dictionary<int, BankAccount>();
        while ((input = Console.ReadLine()) != "End")
        {
            var cmdArgs = input.Split();
            var cmdtype = cmdArgs[0];
            switch (cmdtype)
            {
                case "Create":
                    Create(cmdArgs, accounts);
                    break;

                case "Deposit":
                    Deposit(cmdArgs, accounts);
                    break;

                case "Withdraw":
                    Withdraw(cmdArgs, accounts);
                    break;

                case "Print":
                    Print(cmdArgs, accounts);
                    break;
            }
        }
    }

    private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            var acc = accounts[id];
            Console.WriteLine($"Account ID{acc.ID}, balance {acc.Balance:f2}");
        }
    }

    private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var amount = double.Parse(cmdArgs[2]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            var acc = accounts[id];
            if (acc.Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                acc.Withdraw(amount);
            }
        }
    }

    private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var amount = double.Parse(cmdArgs[2]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            
                accounts[id].Deposit(amount);
            
            
        }
    }

    private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.ID = id;
            accounts.Add(id, acc);
        }
    }
}
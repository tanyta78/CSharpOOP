using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
        this.accounts = new List<BankAccount>();
    }

    public Person(string name, int age, List<BankAccount> accounts) : this(name, age)
    {
        this.accounts = accounts;
    }

    public string Name
    {
        get { return name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return age; }
        set { this.age = value; }
    }

    public List<BankAccount> Accounts
    {
        get { return accounts; }
        set { this.accounts = value; }
    }

    public double GetBalance()
    {
        return this.accounts.Sum(a => a.Balance);
    }
}
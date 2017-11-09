using System;

public class BankAccount
{
    private int id;
    private double balance;

    public int ID
    {
        get { return id; }
        set { this.id = value; }
    }

    public double Balance
    {
        get { return balance; }
        set
        {
            if (this.balance + value < 0)
            {
                throw new ArgumentException("Account cant be less than zero");
            }
            this.balance = value;
        }
    }

    public void Deposit(double amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(double amount)
    {
        this.Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {this.id}, balance {this.balance}";
    }
}
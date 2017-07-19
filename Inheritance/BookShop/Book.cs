using System;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Author
    {
        get { return this.author; }
        set
        {
            var names = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length > 2)
            {
                var lastName = names[names.Length - 1];
                if (char.IsDigit(lastName[0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            this.author = value;
        }
    }

    public string Title
    {
        get { return this.title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            this.title = value;
        }
    }

    public virtual decimal Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Type: ").AppendLine(this.GetType().Name).Append("Title: ").AppendLine(this.Title).Append("Author: ").AppendLine(this.Author).Append("Price: ").AppendLine($"{this.Price:f1}");

        return sb.ToString();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main()
        {
            var personsInput = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var productsInput = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var persons = new List<Person>();
            var products = new List<Product>();

            try
            {
                foreach (var person in personsInput)
                {
                    var info = person.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = info[0];
                    var money = decimal.Parse(info[1]);
                    persons.Add(new Person(name, money));
                }
                foreach (var product in productsInput)
                {
                    var info = product.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = info[0];
                    var cost = decimal.Parse(info[1]);
                    products.Add(new Product(name, cost));
                }

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    var args = input.Split();
                    var personName = args[0];
                    var productName = args[1];

                    var currentPerson = persons.FirstOrDefault(p => p.Name == personName);
                    var currentProduct = products.FirstOrDefault(p => p.Name == productName);

                    try
                    {
                        currentPerson.BuyProduct(currentProduct);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                foreach (var person in persons)
                {
                    var boughtProducts = person.GetProducts();
                    var result = boughtProducts.Any()
                        ? string.Join(", ", boughtProducts.Select(pr => pr.Name).ToList())
                        : "Nothing bought";
                    Console.WriteLine($"{person.Name} - {result}");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace Google
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string inputLine;
            var people = new Dictionary<string, Person>();
            while ((inputLine = Console.ReadLine()) != "End")
            {
                var info = inputLine.Split();
                var personName = info[0];
                if (!people.ContainsKey(personName))
                {
                    people.Add(personName, new Person(personName));
                }

                InsertPersonInfo(people[personName], info);
            }

            var infoFor = Console.ReadLine();
          PrintResult(people[infoFor]);

        }

        private static void InsertPersonInfo(Person person, string[] info)
        {
            if (info.Length == 5)
            {
                //company
                var companyName = info[2];
                var department = info[3];
                var salary = decimal.Parse(info[4]);

                var company = new Company(companyName, department, salary);
                person.CompanyOwned = company;
            }
            else
            {
                switch (info[1])
                {
                    case "pokemon":
                        var pokemonName = info[2];
                        var pokemonType = info[3];

                        person.Pokemons.Add(new Pokemon(pokemonName, pokemonType));

                        break;

                    case "parents":
                        var parentName = info[2];
                        var parentBirthday = info[3];

                        person.Parents.Add(new Parent(parentName, parentBirthday));
                        break;

                    case "children":
                        var childName = info[2];
                        var childBirthday = info[3];

                        person.Children.Add(new Child(childName, childBirthday));

                        break;

                    case "car":
                        var carModel = info[2];
                        var carSpeed = int.Parse(info[3]);

                        person.CarOwned=new Car(carModel,carSpeed);
                        break;
                }
            }
        }

        private static void PrintResult(Person result)
        {
            Console.WriteLine(result.Name);

            Console.WriteLine("Company:");
            if (result.CompanyOwned != null)
            {
                Console.WriteLine($"{result.CompanyOwned.Name} {result.CompanyOwned.Department} {result.CompanyOwned.Salary:f2}");
            }

            Console.WriteLine("Car:");
            if (result.CarOwned != null)
            {
                Console.WriteLine($"{result.CarOwned.Model} {result.CarOwned.Speed}");
            }

            Console.WriteLine("Pokemon:");
            if (result.Pokemons.Count > 0)
            {
                foreach (var pokemon in result.Pokemons)
                {
                    Console.WriteLine($"{pokemon.Name} {pokemon.Type}");
                }
            }

            Console.WriteLine("Parents:");
            if (result.Parents.Count > 0)
            {
                foreach (var parent in result.Parents)
                {
                    Console.WriteLine($"{parent.Name} {parent.Birthday}");
                }
            }

            Console.WriteLine("Children:");
            if (result.Children.Count > 0)
            {
                foreach (var child in result.Children)
                {
                    Console.WriteLine($"{child.Name} {child.Birthday}");
                }
            }
        }

    }
}
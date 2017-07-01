using System;
using System.Collections.Generic;
using System.Linq;

namespace CatLady
{
    public class Program
    {
        public static void Main()
        {
            string input;
            var cats = new List<Cat>();

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                var breed = tokens[0];
                var name = tokens[1];

                switch (breed)
                {
                    case "StreetExtraordinaire":
                        var decibelsOfMeows = int.Parse(tokens[2]);
                        var current = new StreetExtraordinaire();
                        current.Breed = breed;
                        current.Name = name;
                        current.DecibelsOfMeows = decibelsOfMeows;
                        cats.Add(current);
                        break;

                    case "Siamese":
                        var earSize = int.Parse(tokens[2]);
                        var currentCat = new Siamese();
                        currentCat.Breed = breed;
                        currentCat.Name = name;
                        currentCat.EarSize = earSize;
                        cats.Add(currentCat);
                        break;

                    case "Cymric":
                        var furLength = double.Parse(tokens[2]);
                        var currentCymric = new Cymric();
                        currentCymric.Breed = breed;
                        currentCymric.Name = name;
                        currentCymric.FurLength = furLength;
                        cats.Add(currentCymric);
                        break;
                }
            }

            var searchedCatInfo = Console.ReadLine();
            var result = cats.Where(c => c.Name == searchedCatInfo).FirstOrDefault();

            Console.WriteLine(result.ToString());
        }
    }
}
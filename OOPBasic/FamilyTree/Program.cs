using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FamilyTree
{
    public class Program
    {
        public static void Main()
        {
            //read person for whom we search family tree - name or birthday
            string personFamilyTree= Console.ReadLine();

            string input;
            var familyTree=new List<Person>();

            var people = new List<string>();
            
            while ((input=Console.ReadLine())!="End")
            {
               

                if (!input.Contains("-"))
                {
                    var searchedIndex = input.LastIndexOf(" ");

                    var name = input.Substring(0, searchedIndex);
                    var birthday = input.Substring(searchedIndex + 1);

                    familyTree.Add(new Person(name,birthday));
                }
                else
                {
                    people.Add(input);
                }
            }

            foreach (var person in people)
            {
                var info = Regex.Split(person, " - ");
                Person parent;
                Person child;
                if (info[0].Contains('/') && info[1].Contains('/'))
                {
                    var parentBirhtday = info[0];
                    var childrenBirthday = info[1];

                    parent = familyTree
                        .First(p => p.Birthday.Equals(parentBirhtday));
                    child = familyTree
                        .First(p => p.Birthday.Equals(childrenBirthday));
                }
                else if (info[0].Contains('/') || info[1].Contains('/'))
                {
                    var name = string.Empty;
                    var birthday = string.Empty;

                    if (info[0].Contains('/'))
                    {
                        birthday = info[0];
                        name = info[1];

                        parent = familyTree
                            .First(p => p.Birthday.Equals(birthday));
                        child = familyTree
                            .First(p => p.Name.Equals(name));
                    }
                    else
                    {
                        birthday = info[1];
                        name = info[0];

                        child = familyTree
                            .First(p => p.Birthday.Equals(birthday));
                        parent = familyTree
                            .First(p => p.Name.Equals(name));
                    }
                }
                else
                {
                    var parentName = info[0];
                    var childrenName = info[1];

                    parent = familyTree
                        .First(p => p.Name.Equals(parentName));
                    child = familyTree
                        .First(p => p.Name.Equals(childrenName));
                }

                if (!parent.Children.Contains(child))
                {
                    parent.Children.Add(child);
                }

                if (!child.Parents.Contains(parent))
                {
                    child.Parents.Add(parent);
                }
            }

            Person searchedPerson;

            if (personFamilyTree.Contains('/'))
            {
                searchedPerson = familyTree.First(p => p.Birthday.Equals(personFamilyTree));
            }
            else
            {
                searchedPerson = familyTree.First(p => p.Name.Equals(personFamilyTree));
            }

            var result = new StringBuilder();

            result.AppendLine(searchedPerson.ToString());

            result.AppendLine("Parents:");
            foreach (var parent in searchedPerson.Parents)
            {
                result.AppendLine(parent.ToString());
            }

            result.AppendLine("Children:");
            foreach (var child in searchedPerson.Children)
            {
                result.AppendLine(child.ToString());
            }

            Console.Write(result);
        }
    }
}
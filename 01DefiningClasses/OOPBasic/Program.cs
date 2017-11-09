using System;
using System.Linq;
using System.Reflection;

public class Program
{
    private static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        int numberOfPeople = int.Parse(Console.ReadLine());
        var family = new Family();
        for (int i = 0; i < numberOfPeople; i++)
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            var person = new Person(input[0], int.Parse(input[1]));
            family.AddMember(person);
        }
        family.GetOldestMember();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> family = new List<Person>();

    public void AddMember(Person member)
    {
        family.Add(member);
    }

    public void GetOldestMember()
    {
        var oldest = family.OrderByDescending(x => x.Age).First();
        Console.WriteLine($"{oldest.Name} {oldest.Age}");
    }
}
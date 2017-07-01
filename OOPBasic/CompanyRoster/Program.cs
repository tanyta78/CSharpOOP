using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int numberOfEmployees = int.Parse(Console.ReadLine());

        var allEmployees = new List<Employee>();

        for (int i = 0; i < numberOfEmployees; i++)
        {
            var inputInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var currentName = inputInfo[0];
            var currentSalary = decimal.Parse(inputInfo[1]);
            var currentPosition = inputInfo[2];
            var currentDepartment = inputInfo[3];
            var currentEmployee = new Employee(currentName, currentSalary, currentPosition, currentDepartment);

            if (inputInfo.Length > 4)
            {
                if (inputInfo[4].Contains('@'))
                {
                    currentEmployee.email = inputInfo[4];
                }
                else
                {
                    currentEmployee.age = int.Parse(inputInfo[4]);
                }
            }

            if (inputInfo.Length > 5)
            {
                currentEmployee.age = int.Parse(inputInfo[5]);
            }

            allEmployees.Add(currentEmployee);
        }

        var result = allEmployees
            .GroupBy(e => e.department)
            .Select(e => new
            {
                Department = e.Key,
                AverageSalary = e.Average(emp => emp.salary),
                Employees = e.OrderByDescending(emp => emp.salary)
            })
            .OrderByDescending(dep => dep.AverageSalary)
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {result.Department}");

        foreach (var employee in result.Employees)
        {
            Console.WriteLine($"{employee.name} {employee.salary:F2} {employee.email} {employee.age}");
        }
    }
}
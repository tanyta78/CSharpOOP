public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public Person(string firstName, string lastName, int age, double salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public void IncreaseSalary(double bonus)
    {
        if (this.Age < 30)
        {
            this.salary += this.salary * bonus / 200;
        }
        else
        {
            this.salary += this.salary * bonus / 100;
        }
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} get {this.salary:f2} leva";
    }
}
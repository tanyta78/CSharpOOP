using System.Collections.Generic;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.Name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return firstTeam.AsReadOnly(); }
    }

    public IReadOnlyCollection<Person> ReserveTeam
    {
        get { return reserveTeam.AsReadOnly(); }
    }

    public void AddPlayer(Person player)
    {
        if (player.Age < 40)
        {
            firstTeam.Add(player);
        }
        else
        {
            reserveTeam.Add(player);
        }
    }
}
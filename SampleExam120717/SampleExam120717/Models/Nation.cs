using System.Collections.Generic;
using System.Text;

public abstract class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;
    private double totalPower;

    public Nation()
    {
        this.Monuments = new List<Monument>();
        this.Benders = new List<Bender>();
    }

    public List<Bender> Benders
    {
        get { return benders; }
        set { benders = value; }
    }

    public List<Monument> Monuments
    {
        get { return monuments; }
        set { monuments = value; }
    }

    public double TotalPower
    {
        get { return totalPower; }
        set { totalPower = value; }
    }

    public void GetTotalPowerPoints()
    {
        double benderPoints = 0;
        foreach (var bender in this.benders)
        {
            benderPoints += bender.GetBenderTotalPower();
        }

        int monumentsPoints = 0;
        foreach (var monument in this.monuments)
        {
            monumentsPoints += monument.GetMonumentPoints();
        }

        var increase = (benderPoints / 100) * monumentsPoints;

        this.totalPower = benderPoints + increase;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var name = this.GetType().Name.Substring(0, this.GetType().Name.Length - 6);
        sb.AppendLine($"{name} Nation");
        sb.Append("Benders:");
        if (this.Benders.Count == 0)
        {
            sb.AppendLine(" None");
        }
        else
        {
            sb.AppendLine();
            foreach (var bender in this.Benders)
            {
                sb.AppendLine($"###{bender.ToString()}");
            }
        }
        sb.Append("Monuments:");
        if (this.Monuments.Count == 0)
        {
            sb.AppendLine(" None");
        }
        else
        {
            sb.AppendLine();
            foreach (var monument in this.Monuments)
            {
                sb.AppendLine($"###{monument.ToString()}");
            }
        }

        return sb.ToString().Trim();
    }
}
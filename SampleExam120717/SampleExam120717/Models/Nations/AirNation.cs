using System.Text;

public class AirNation : Nation
{
    public AirNation() : base()
    {
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Air Nation");
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

        return sb.ToString();
    }
}
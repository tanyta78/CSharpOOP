using System;

public class DateModifier
{
    private string firstDate;
    private string secondDate;

    public string FirstDate
    {
        get { return firstDate; }
        set { this.firstDate = value; }
    }
    public string SecondDate
    {
        get { return secondDate; }
        set { this.secondDate = value; }
    }

    public void CalculateDifferenceBetweenTwoDates(string fdate, string sdate)
    {
        DateTime date1 = DateTime.Parse(fdate);
        DateTime date2 = DateTime.Parse(sdate);
        var result = Math.Abs((date1 - date2).TotalDays);
        Console.WriteLine(result);
    }
}
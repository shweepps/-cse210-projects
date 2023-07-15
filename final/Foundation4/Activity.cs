using System;

public class Activity
{
    public string Date { get; private set; }
    public int Length { get; private set; }

    public Activity(string date, int length)
    {
        Date = date;
        Length = length;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();
        return $"{Date} {GetType().Name} ({Length} min) - Distance: {distance:F1} miles, Speed: {speed:F1} mph, Pace: {pace:F1} min/mile";
    }
}

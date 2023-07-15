public class Swimming : Activity
{
    public int Laps { get; private set; }

    public Swimming(string date, int length, int laps) : base(date, length)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000 * 0.62;
    }

    public override double GetSpeed()
    {
        return GetDistance() / Length * 60;
    }

    public override double GetPace()
    {
        return Length / GetDistance();
    }
}

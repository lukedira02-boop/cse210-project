public class Swimming : Activity
{
    private const double MilesPerMeter = 0.62 / 1000;
    private readonly int _laps;

    public Swimming(DateTime date, int length, int laps)
        : base(date, length)
    {
        if (laps <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(laps), "Swimming laps must be greater than zero.");
        }

        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 * MilesPerMeter;
    }

    public override double GetSpeed()
    {
        return GetDistance() / GetLength() * 60;
    }

    public override double GetPace()
    {
        return GetLength() / GetDistance();
    }
}

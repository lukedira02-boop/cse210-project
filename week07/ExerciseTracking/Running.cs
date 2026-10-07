public class Running : Activity
{
    private readonly double _distance;

    public Running(DateTime date, int length, double distance)
        : base(date, length)
    {
        if (distance <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(distance), "Running distance must be greater than zero.");
        }

        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
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

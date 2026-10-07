public class Cycling : Activity
{
    private readonly double _speed;

    public Cycling(DateTime date, int length, double speed)
        : base(date, length)
    {
        if (speed <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(speed), "Cycling speed must be greater than zero.");
        }

        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * GetLength() / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return GetLength() / GetDistance();
    }
}

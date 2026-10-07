using System.Globalization;

public abstract class Activity
{
    private readonly DateTime _date;
    private readonly int _length;

    protected Activity(DateTime date, int length)
    {
        if (length <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length), "Activity length must be greater than zero.");
        }

        _date = date;
        _length = length;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        string date = _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        return $"{date} {GetType().Name} ({_length} min): " +
               $"Distance {GetDistance():F1} miles, " +
               $"Speed: {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }

    protected int GetLength()
    {
        return _length;
    }
}

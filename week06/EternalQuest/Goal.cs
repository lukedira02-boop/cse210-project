public abstract class Goal
{
    private readonly string _name;
    private readonly string _description;
    private readonly int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;
    public abstract bool IsComplete { get; }

    public abstract int RecordEvent();
    public abstract string GetDetailsString();
    public abstract GoalSaveData ToSaveData();

    public static Goal FromSaveData(GoalSaveData data)
    {
        if (string.IsNullOrWhiteSpace(data.Name) ||
            string.IsNullOrWhiteSpace(data.Description) ||
            data.Points <= 0)
        {
            throw new FormatException("A saved goal has invalid common details.");
        }

        return data.Type switch
        {
            "Simple" => CreateSimpleGoal(data),
            "Eternal" => CreateEternalGoal(data),
            "Checklist" => CreateChecklistGoal(data),
            _ => throw new FormatException($"Unknown saved goal type: {data.Type}")
        };
    }

    private static Goal CreateSimpleGoal(GoalSaveData data)
    {
        if (data.Count != 0 || data.TargetCount != 0 || data.BonusPoints != 0)
        {
            throw new FormatException("A saved simple goal has invalid progress details.");
        }

        return new SimpleGoal(data.Name, data.Description, data.Points, data.IsComplete);
    }

    private static Goal CreateEternalGoal(GoalSaveData data)
    {
        if (data.IsComplete || data.Count != 0 || data.TargetCount != 0 || data.BonusPoints != 0)
        {
            throw new FormatException("A saved eternal goal has invalid progress details.");
        }

        return new EternalGoal(data.Name, data.Description, data.Points);
    }

    private static Goal CreateChecklistGoal(GoalSaveData data)
    {
        if (data.TargetCount <= 0 ||
            data.Count < 0 ||
            data.Count > data.TargetCount ||
            data.BonusPoints < 0 ||
            data.IsComplete != (data.Count == data.TargetCount))
        {
            throw new FormatException("A saved checklist goal has invalid progress details.");
        }

        return new ChecklistGoal(
            data.Name,
            data.Description,
            data.Points,
            data.TargetCount,
            data.BonusPoints,
            data.Count);
    }
}

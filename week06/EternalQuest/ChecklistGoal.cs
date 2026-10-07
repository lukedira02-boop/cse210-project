public class ChecklistGoal : Goal
{
    private readonly int _targetCount;
    private readonly int _bonusPoints;
    private int _count;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonusPoints,
        int count = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _count = count;
    }

    public override bool IsComplete => _count >= _targetCount;

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }

        _count++;
        return Points + (IsComplete ? _bonusPoints : 0);
    }

    public override string GetDetailsString()
    {
        string status = IsComplete ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description}) -- Completed {_count}/{_targetCount} times";
    }

    public override GoalSaveData ToSaveData()
    {
        return new GoalSaveData
        {
            Type = "Checklist",
            Name = Name,
            Description = Description,
            Points = Points,
            IsComplete = IsComplete,
            Count = _count,
            TargetCount = _targetCount,
            BonusPoints = _bonusPoints
        };
    }
}

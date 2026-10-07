public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override bool IsComplete => false;

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {Name} ({Description})";
    }

    public override GoalSaveData ToSaveData()
    {
        return new GoalSaveData
        {
            Type = "Eternal",
            Name = Name,
            Description = Description,
            Points = Points
        };
    }
}

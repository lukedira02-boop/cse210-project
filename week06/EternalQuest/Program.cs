using System.Text.Json;

// Creativity extension: the quest awards a new level for every 1,000 points.
// The current level and progress toward the next level are derived from the saved score.
const string DefaultSavePath = "eternal-quest.json";
const int PointsPerLevel = 1000;

List<Goal> goals = [];
long score = 0;

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Eternal Quest");
    DisplayQuestStatus(score);
    Console.WriteLine("  1. Create a new goal");
    Console.WriteLine("  2. Record an event");
    Console.WriteLine("  3. Show goals");
    Console.WriteLine("  4. Save quest");
    Console.WriteLine("  5. Load quest");
    Console.WriteLine("  6. Quit");
    Console.Write("Select an option: ");

    string choice = Console.ReadLine() ?? "";
    switch (choice)
    {
        case "1":
            CreateGoal(goals);
            break;
        case "2":
            RecordGoalEvent(goals, ref score);
            break;
        case "3":
            DisplayGoals(goals);
            break;
        case "4":
            SaveQuest(goals, score);
            break;
        case "5":
            LoadQuest(ref goals, ref score);
            break;
        case "6":
            Console.WriteLine("Keep going on your Eternal Quest!");
            return;
        default:
            Console.WriteLine("Please select a number from 1 to 6.");
            break;
    }
}

static void DisplayQuestStatus(long score)
{
    long level = score / PointsPerLevel + 1;
    long levelProgress = score % PointsPerLevel;
    Console.WriteLine($"Score: {score} points | Level {level} ({levelProgress}/{PointsPerLevel} to next level)");
}

static void CreateGoal(List<Goal> goals)
{
    Console.WriteLine();
    Console.WriteLine("Goal types:");
    Console.WriteLine("  1. Simple goal");
    Console.WriteLine("  2. Eternal goal");
    Console.WriteLine("  3. Checklist goal");
    string type = ReadChoice("Choose a goal type: ", ["1", "2", "3"]);

    string name = ReadRequiredText("Goal name: ");
    string description = ReadRequiredText("Goal description: ");
    int points = ReadPositiveInt("Points for each completion: ");

    Goal goal = type switch
    {
        "1" => new SimpleGoal(name, description, points),
        "2" => new EternalGoal(name, description, points),
        "3" => new ChecklistGoal(
            name,
            description,
            points,
            ReadPositiveInt("How many times must it be completed? "),
            ReadNonnegativeInt("Bonus points for completing the checklist: ")),
        _ => throw new InvalidOperationException("The goal type was not recognized.")
    };

    goals.Add(goal);
    Console.WriteLine($"Added goal: {goal.Name}");
}

static void RecordGoalEvent(List<Goal> goals, ref long score)
{
    if (goals.Count == 0)
    {
        Console.WriteLine("Create a goal before recording an event.");
        return;
    }

    DisplayGoals(goals);
    int index = ReadIndex("Which goal did you accomplish? ", goals.Count);
    int awardedPoints = goals[index].RecordEvent();

    if (awardedPoints == 0)
    {
        Console.WriteLine("That goal is already complete; no points were awarded.");
        return;
    }

    score = checked(score + awardedPoints);
    Console.WriteLine($"Congratulations! You earned {awardedPoints} points.");
    DisplayQuestStatus(score);
}

static void DisplayGoals(List<Goal> goals)
{
    Console.WriteLine();
    Console.WriteLine("Your goals:");
    if (goals.Count == 0)
    {
        Console.WriteLine("No goals have been created yet.");
        return;
    }

    for (int index = 0; index < goals.Count; index++)
    {
        Console.WriteLine($"{index + 1}. {goals[index].GetDetailsString()}");
    }
}

static void SaveQuest(List<Goal> goals, long score)
{
    string path = ReadSavePath();
    QuestSaveData saveData = new()
    {
        Score = score,
        Goals = goals.Select(goal => goal.ToSaveData()).ToList()
    };

    try
    {
        string json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
        Console.WriteLine($"Quest saved to {path}.");
    }
    catch (IOException exception)
    {
        Console.WriteLine($"Could not save the quest: {exception.Message}");
    }
    catch (UnauthorizedAccessException exception)
    {
        Console.WriteLine($"Could not save the quest: {exception.Message}");
    }
}

static void LoadQuest(ref List<Goal> goals, ref long score)
{
    string path = ReadSavePath();
    try
    {
        string json = File.ReadAllText(path);
        QuestSaveData? saveData = JsonSerializer.Deserialize<QuestSaveData>(json);
        if (saveData is null || saveData.Score < 0 || saveData.Goals is null)
        {
            throw new FormatException("The save file is missing valid quest data.");
        }

        List<Goal> loadedGoals = saveData.Goals
            .Select(goalData => Goal.FromSaveData(goalData ??
                throw new FormatException("The save file contains an empty goal.")))
            .ToList();

        goals = loadedGoals;
        score = saveData.Score;
        Console.WriteLine($"Quest loaded from {path}.");
        DisplayQuestStatus(score);
    }
    catch (IOException exception)
    {
        Console.WriteLine($"Could not load the quest: {exception.Message}");
    }
    catch (UnauthorizedAccessException exception)
    {
        Console.WriteLine($"Could not load the quest: {exception.Message}");
    }
    catch (JsonException exception)
    {
        Console.WriteLine($"The save file contains invalid JSON: {exception.Message}");
    }
    catch (FormatException exception)
    {
        Console.WriteLine($"The save file contains invalid quest data: {exception.Message}");
    }
}

static string ReadSavePath()
{
    Console.Write($"File path (press Enter for {DefaultSavePath}): ");
    string path = Console.ReadLine() ?? "";
    return string.IsNullOrWhiteSpace(path) ? DefaultSavePath : path.Trim();
}

static string ReadRequiredText(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string value = Console.ReadLine()?.Trim() ?? "";
        if (!string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        Console.WriteLine("This value cannot be empty.");
    }
}

static string ReadChoice(string prompt, string[] validChoices)
{
    while (true)
    {
        Console.Write(prompt);
        string choice = Console.ReadLine() ?? "";
        if (validChoices.Contains(choice))
        {
            return choice;
        }

        Console.WriteLine($"Please choose one of: {string.Join(", ", validChoices)}.");
    }
}

static int ReadPositiveInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
        {
            return value;
        }

        Console.WriteLine("Enter a whole number greater than zero.");
    }
}

static int ReadNonnegativeInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int value) && value >= 0)
        {
            return value;
        }

        Console.WriteLine("Enter a whole number greater than or equal to zero.");
    }
}

static int ReadIndex(string prompt, int itemCount)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int displayedIndex) &&
            displayedIndex >= 1 &&
            displayedIndex <= itemCount)
        {
            return displayedIndex - 1;
        }

        Console.WriteLine($"Enter a number from 1 to {itemCount}.");
    }
}

// Creativity extension: reflection questions and activity prompts are shuffled
// and will not repeat until every item in that activity's pool has been used.
while (true)
{
    Console.Clear();
    Console.WriteLine("Mindfulness Program");
    Console.WriteLine("  1. Breathing activity");
    Console.WriteLine("  2. Reflection activity");
    Console.WriteLine("  3. Listing activity");
    Console.WriteLine("  4. Quit");
    Console.Write("Choose an activity: ");

    string choice = Console.ReadLine() ?? "";
    Activity? activity = choice switch
    {
        "1" => new BreathingActivity(),
        "2" => new ReflectionActivity(),
        "3" => new ListingActivity(),
        "4" => null,
        _ => null
    };

    if (choice == "4")
    {
        break;
    }

    if (activity is null)
    {
        Console.WriteLine("Please choose 1, 2, 3, or 4.");
        Activity.ShowSpinner(2);
        continue;
    }

    Console.Clear();
    activity.Run();
    Console.WriteLine();
    Console.Write("Press Enter to return to the menu.");
    Console.ReadLine();
}

Console.WriteLine("Take care.");
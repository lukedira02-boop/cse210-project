using System.Text.Json;

// Creativity extension: entries include a mood, and JSON persistence preserves
// commas and quotation marks in responses without requiring CSV escaping.

Journal journal = new();
bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("Journal Menu");
    Console.WriteLine("1. Write a new entry");
    Console.WriteLine("2. Display the journal");
    Console.WriteLine("3. Save the journal");
    Console.WriteLine("4. Load the journal");
    Console.WriteLine("5. Quit");
    Console.Write("Select an option: ");
    string choice = Console.ReadLine() ?? "";

    try
    {
        switch (choice)
        {
            case "1":
                WriteEntry(journal);
                break;
            case "2":
                journal.DisplayEntries();
                break;
            case "3":
                SaveJournal(journal);
                break;
            case "4":
                LoadJournal(journal);
                break;
            case "5":
                running = false;
                break;
            default:
                Console.WriteLine("Please choose an option from 1 to 5.");
                break;
        }
    }
    catch (IOException exception)
    {
        Console.WriteLine($"File error: {exception.Message}");
    }
    catch (JsonException exception)
    {
        Console.WriteLine($"Could not read the journal: {exception.Message}");
    }
}

static void WriteEntry(Journal journal)
{
    string prompt = journal.GetRandomPrompt();
    Console.WriteLine($"\n{prompt}");
    Console.Write("Response: ");
    string response = Console.ReadLine() ?? "";
    Console.Write("Mood: ");
    string mood = Console.ReadLine() ?? "";
    journal.AddEntry(new Entry(prompt, response, mood));
    Console.WriteLine("Entry saved in the current journal.");
}

static void SaveJournal(Journal journal)
{
    Console.Write("Filename: ");
    string filename = Console.ReadLine() ?? "journal.json";
    journal.Save(filename);
    Console.WriteLine("Journal saved.");
}

static void LoadJournal(Journal journal)
{
    Console.Write("Filename: ");
    string filename = Console.ReadLine() ?? "journal.json";
    journal.Load(filename);
    Console.WriteLine("Journal loaded.");
}
using System.Text.Json;

public class Journal
{
    private readonly List<Entry> _entries = new();
    private readonly Random _random = new();
    private readonly string[] _prompts =
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one small thing I am grateful for right now?",
        "What did I learn today that I want to remember?"
    };

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Length)];
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries have been written yet.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void Save(string filename)
    {
        string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
    }

    public void Load(string filename)
    {
        string json = File.ReadAllText(filename);
        List<Entry>? loadedEntries = JsonSerializer.Deserialize<List<Entry>>(json);

        if (loadedEntries is null)
        {
            throw new InvalidDataException("The file did not contain a valid journal.");
        }

        _entries.Clear();
        _entries.AddRange(loadedEntries);
    }
}
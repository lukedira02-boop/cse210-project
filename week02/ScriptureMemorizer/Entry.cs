public class Entry
{
    public string Date { get; set; } = "";
    public string Prompt { get; set; } = "";
    public string Response { get; set; } = "";
    public string Mood { get; set; } = "";

    public Entry()
    {
    }

    public Entry(string prompt, string response, string mood)
    {
        Date = DateTime.Now.ToShortDateString();
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine(new string('-', 50));
    }
}
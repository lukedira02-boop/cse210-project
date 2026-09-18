// Creativity extension: the program chooses a scripture from a small library
// at startup and hides only words that are still visible, so every round makes
// measurable progress toward memorizing the selected scripture.
List<Scripture> scriptures =
[
    new Scripture(new Reference("John", 3, 16),
        "For God so loved the world, that he gave his only begotten Son, " +
        "that whosoever believeth in him should not perish, but have everlasting life."),
    new Scripture(new Reference("Proverbs", 3, 5, 6),
        "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
        "In all thy ways acknowledge him, and he shall direct thy paths."),
    new Scripture(new Reference("Philippians", 4, 13),
        "I can do all things through Christ which strengtheneth me.")
];

Random random = new();
Scripture scripture = scriptures[random.Next(scriptures.Count)];

while (true)
{
    Console.Clear();
    Console.WriteLine(scripture.GetDisplayText());

    if (scripture.IsCompletelyHidden())
    {
        break;
    }

    Console.WriteLine();
    Console.Write("Press Enter to hide words or type quit: ");
    string response = Console.ReadLine() ?? "";

    if (response.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    scripture.HideRandomWords(3);
}
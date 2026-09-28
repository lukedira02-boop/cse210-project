using System.Diagnostics;
using System.Text;

public class ListingActivity : Activity
{
    private readonly PromptCycle _prompts = new(
    [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ]);

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {_prompts.Next()} ---");
        Console.Write("You may begin in: ");
        ShowCountdown(5);

        Stopwatch timer = StartTimer();
        int itemCount = 0;
        StringBuilder currentItem = new();

        Console.Write("Start listing (press Enter after each item): ");
        while (RemainingSeconds(timer, Duration) > 0)
        {
            if (!Console.KeyAvailable)
            {
                Thread.Sleep(50);
                continue;
            }

            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Enter)
            {
                if (!string.IsNullOrWhiteSpace(currentItem.ToString()))
                {
                    itemCount++;
                }

                currentItem.Clear();
                Console.WriteLine();
                if (RemainingSeconds(timer, Duration) > 0)
                {
                    Console.Write("Next item: ");
                }
            }
            else if (key.Key == ConsoleKey.Backspace && currentItem.Length > 0)
            {
                currentItem.Length--;
                Console.Write("\b \b");
            }
            else if (!char.IsControl(key.KeyChar))
            {
                currentItem.Append(key.KeyChar);
                Console.Write(key.KeyChar);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {itemCount} items.");
    }
}
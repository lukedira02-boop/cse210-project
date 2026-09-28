using System.Diagnostics;

public class ReflectionActivity : Activity
{
    private readonly PromptCycle _prompts = new(
    [
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ]);

    private readonly PromptCycle _questions = new(
    [
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ]);

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {_prompts.Next()} ---");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Stopwatch timer = StartTimer();
        while (RemainingSeconds(timer, Duration) > 0)
        {
            Console.Write($"{_questions.Next()} ");
            ShowSpinner(Math.Min(5, RemainingSeconds(timer, Duration)));
            Console.WriteLine();
        }
    }
}
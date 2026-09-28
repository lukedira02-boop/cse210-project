using System.Diagnostics;

public abstract class Activity
{
    private readonly string _name;
    private readonly string _description;
    private int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected int Duration => _duration;

    public void Run()
    {
        if (!StartActivity())
        {
            return;
        }

        PerformActivity();
        EndActivity();
    }

    protected abstract void PerformActivity();

    protected static Stopwatch StartTimer()
    {
        Stopwatch timer = Stopwatch.StartNew();
        return timer;
    }

    protected static int RemainingSeconds(Stopwatch timer, int duration)
    {
        return Math.Max(0, (int)Math.Ceiling(duration - timer.Elapsed.TotalSeconds));
    }

    protected static void ShowCountdown(int seconds)
    {
        for (int remaining = seconds; remaining > 0; remaining--)
        {
            Console.Write($"{remaining} ");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }

    public static void ShowSpinner(int seconds)
    {
        char[] frames = ['|', '/', '-', '\\'];
        Stopwatch timer = Stopwatch.StartNew();
        int frame = 0;

        while (timer.Elapsed.TotalSeconds < seconds)
        {
            Console.Write(frames[frame % frames.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            frame++;
        }
    }

    private bool StartActivity()
    {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out _duration) && _duration > 0)
            {
                break;
            }

            Console.WriteLine("Please enter a whole number greater than zero.");
        }

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
        return true;
    }

    private void EndActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }
}
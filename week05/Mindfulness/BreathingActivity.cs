using System.Diagnostics;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        Stopwatch timer = StartTimer();
        bool breatheIn = true;

        while (RemainingSeconds(timer, Duration) > 0)
        {
            int breathDuration = Math.Min(4, RemainingSeconds(timer, Duration));
            Console.WriteLine(breatheIn ? "Breathe in..." : "Breathe out...");
            ShowCountdown(breathDuration);
            breatheIn = !breatheIn;
        }
    }
}
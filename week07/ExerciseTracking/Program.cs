List<Activity> activities =
[
    new Running(new DateTime(2026, 10, 1), 30, 3.0),
    new Cycling(new DateTime(2026, 10, 2), 30, 15.0),
    new Swimming(new DateTime(2026, 10, 3), 30, 20)
];

foreach (Activity activity in activities)
{
    Console.WriteLine(activity.GetSummary());
}

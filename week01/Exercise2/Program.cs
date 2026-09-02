Console.Write("What is your grade percentage? ");
int percentage = int.Parse(Console.ReadLine() ?? "0");

string letter;
if (percentage >= 90)
{
	letter = "A";
}
else if (percentage >= 80)
{
	letter = "B";
}
else if (percentage >= 70)
{
	letter = "C";
}
else if (percentage >= 60)
{
	letter = "D";
}
else
{
	letter = "F";
}

string sign = "";
int lastDigit = percentage % 10;
if (letter == "A")
{
	if (lastDigit < 3)
	{
		sign = "-";
	}
}
else if (letter != "F")
{
	if (lastDigit >= 7)
	{
		sign = "+";
	}
	else if (lastDigit < 3)
	{
		sign = "-";
	}
}

Console.WriteLine($"Your grade is: {letter}{sign}");
if (percentage >= 70)
{
	Console.WriteLine("You passed the course. Congratulations!");
}
else
{
	Console.WriteLine("Keep working hard and you will do better next time.");
}

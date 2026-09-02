List<int> numbers = new List<int>();
int number;

Console.WriteLine("Enter a list of numbers, type 0 when finished.");
do
{
	Console.Write("Enter number: ");
	number = int.Parse(Console.ReadLine() ?? "0");
	if (number != 0)
	{
		numbers.Add(number);
	}
} while (number != 0);

if (numbers.Count > 0)
{
	int sum = 0;
	int largest = numbers[0];
	int smallestPositive = 0;

	foreach (int value in numbers)
	{
		sum += value;
		if (value > largest)
		{
			largest = value;
		}
		if (value > 0 && (smallestPositive == 0 || value < smallestPositive))
		{
			smallestPositive = value;
		}
	}

	double average = (double)sum / numbers.Count;
	Console.WriteLine($"The sum is: {sum}");
	Console.WriteLine($"The average is: {average}");
	Console.WriteLine($"The largest number is: {largest}");

	if (smallestPositive > 0)
	{
		Console.WriteLine($"The smallest positive number is: {smallestPositive}");
	}

	numbers.Sort();
	Console.WriteLine("The sorted list is:");
	foreach (int value in numbers)
	{
		Console.WriteLine(value);
	}
}

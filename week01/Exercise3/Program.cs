Random randomGenerator = new Random();
string playAgain;

do
{
	int magicNumber = randomGenerator.Next(1, 101);
	int guessCount = 0;
	int guess = 0;

	Console.WriteLine("Guess my number!");
	while (guess != magicNumber)
	{
		Console.Write("What is your guess? ");
		guess = int.Parse(Console.ReadLine() ?? "0");
		guessCount++;

		if (guess < magicNumber)
		{
			Console.WriteLine("Higher");
		}
		else if (guess > magicNumber)
		{
			Console.WriteLine("Lower");
		}
		else
		{
			Console.WriteLine("You guessed it!");
			Console.WriteLine($"You made {guessCount} guesses.");
		}
	}

	Console.Write("Do you want to play again? ");
	playAgain = (Console.ReadLine() ?? "").Trim().ToLower();
} while (playAgain == "yes");

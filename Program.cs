using System;

Console.WriteLine("Welcome to the Guess the Number game!");


Console.WriteLine("Enter max number: ");
int maxNumber = int.Parse(Console.ReadLine()!);

Console.WriteLine($"I am thinking of a number between 1 and {maxNumber}.");

var random = new Random();
var playAgain = true;

while (playAgain)
{
    int target = random.Next(1, maxNumber + 1);
    int maxAttempts = maxNumber / 10 + 3;
    int attempts = 0;
    bool won = false;

    while (attempts < maxAttempts)
    {
        Console.Write($"Attempt {attempts + 1}/{maxAttempts}. Enter your guess: ");

        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int guess))
        {
            Console.WriteLine("Please enter a valid whole number.");
            continue;
        }

        attempts++;

        if (guess < target)
        {
            Console.WriteLine("Too low! Try a higher number.");
        }
        else if (guess > target)
        {
            Console.WriteLine("Too high! Try a lower number.");
        }
        else
        {
            won = true;
            Console.WriteLine($"Congratulations! You guessed the number {target} in {attempts} attempts.");
            break;
        }
    }

    if (!won)
    {
        Console.WriteLine($"Sorry, you ran out of attempts. The number was {target}.");
    }

    Console.Write("Do you want to play again? (y/n): ");
    string? replayChoice = Console.ReadLine();

    playAgain = replayChoice is not null && replayChoice.Trim().Equals("y", StringComparison.OrdinalIgnoreCase);
    Console.WriteLine();
}

Console.WriteLine("Thanks for playing! Goodbye.");

using System;

class Program
{
    static void Main(string[] args)
    {
        string Again = "";

        do
        {
            
            Random randomGenerator = new Random();
            int IntMagicNumber = randomGenerator.Next(1, 101);
            Console.WriteLine("Guess the magic number!");

            Console.Write("What is your guess? ");
            string Guess = Console.ReadLine();
            int IntGuess = int.Parse(Guess);

            int Attempts = 1;

            while(IntGuess != IntMagicNumber)
            {
                if (IntMagicNumber > IntGuess)
                {
                Console.WriteLine("Higher");
                }
                else if (IntMagicNumber < IntGuess)
                {
                Console.WriteLine("Lower");
                }
                Console.Write("What is your guess? ");
                Guess = Console.ReadLine();
                IntGuess = int.Parse(Guess);
                Attempts++;
            }

            Console.WriteLine("You guessed it");
            Console.WriteLine($"You tried {Attempts} times");
            Console.Write("Do you want to continue playing? (yes/no)");
            Again = Console.ReadLine();

        }while (Again == "yes");

        Console.WriteLine("Thanks for playing!");

    }
}
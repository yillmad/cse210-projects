using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int secondDigit = percent%10;
        string Signal = "";

        if (secondDigit >= 7 && percent < 90 && percent > 60)
        {
            Signal = "+";
        }

        else if (secondDigit < 3 && percent > 60)
        {
            Signal = "-";
        }

        else
        {
            Signal = "";
        } 

        Console.WriteLine($"Your grade is: {letter}{Signal}");
        
        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("You didn't passed!");
        }
    }
}
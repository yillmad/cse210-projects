using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the journal Program!");
        Entry myChoice = new Entry();
        Journal myEntry = new Journal();
        DayRating myRating = new DayRating();
        PromptGenerator myPrompts = new PromptGenerator();
        myPrompts._prompts.Add("Who was the most interesting person you interacted with today and why?");
        myPrompts._prompts.Add("What are you planning to do this weekend?");
        myPrompts._prompts.Add("If you had one thing you could do over today, what would it be?");
        myPrompts._prompts.Add("What challenges did you face, and how did you overcome them?");
        myPrompts._prompts.Add("If you had one thing you could do over today, what would it be?");
        myPrompts._prompts.Add("What was the best part of your day?");
        myPrompts._prompts.Add("What did you learn today that you didn't know before?");
       
        myPrompts._prompt = "";
        myEntry._entry = "";
        
        while (true)
        {
            myChoice.DisplayMenu();
            myChoice._answer = Console.ReadLine();

            if (myChoice._answer == "1")
            {
                int rating =myRating.RateDay();

                if (rating < 4)
                Console.WriteLine("Tough days build stronger people. Keep going.");
                else if (rating > 3 && rating < 6)
                Console.WriteLine("Today may have been uneventful, but remember that every small step counts towards your bigger goals.");
                else if (rating > 5 && rating < 11)
                Console.WriteLine("Congratulations on a great day! Take a moment to bask in your achievements and remember this feeling.");

                myPrompts._prompt = myPrompts.GetRandomPrompt();
                Console.WriteLine(myPrompts._prompt);
                myEntry._entry = Console.ReadLine();
                myEntry.SaveEntries(myEntry._entry, myPrompts._prompt, rating);
            }
            else if (myChoice._answer == "2")
            {
                myEntry.DisplayEntries();
            }
            else if (myChoice._answer == "3")
            {
                Console.Write("Please type the name of the file: ");
                string fileOpen = Console.ReadLine();
                myEntry.LoadFile(fileOpen);
            }
            else if (myChoice._answer == "4")
            {
                Console.Write("Please type the name of the file, like this 'myfile.txt': ");
                string fileName = Console.ReadLine();
                myEntry.SaveToFile(fileName);
            }
            else if (myChoice._answer == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Not a valid answer");
            }
        }

    }
}
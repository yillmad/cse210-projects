using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        ReferenceManager reference = new ReferenceManager();
        reference.LoadReferences();

        ScriptureManager scripture = new ScriptureManager();
        scripture.LoadScriptures();

        WordManager wordManager = new WordManager();
        ScriptureEditor scriptureEditor = new ScriptureEditor();

        Console.WriteLine("\n**** Welcome to the Scripture Memorizer App ****");

        int userChoice = 0;

        while (userChoice != 4)
        {
            userChoice = GetUserChoice();

            switch (userChoice)
            {
                case 1:
                    reference.DisplayReferences();
                    break;
                case 2:
                    string script = scripture.GetRandomScripture();
                    string ref1 = reference.GetReference(scripture);
                    wordManager.RenderWords(scripture);
                    wordManager.RenderReference(scripture);

                    while (wordManager.HiddenWords.Count < wordManager.WordList.Length)
                    {
                        wordManager.Show(ref1);
                        wordManager.HandleUserInput();
                    }
                    wordManager.Show(ref1);
                    break;
                case 3:
                    scriptureEditor.AddNewScripture();
                    break;
                case 4:
                    Console.WriteLine("\n*** Thanks for using the Scripture Memorizer App! ***\n");
                    break;
                default:
                    Console.WriteLine("\nSorry, the option you entered is not valid.");
                    break;
            }
        }
    }

    static int GetUserChoice()
    {
        Console.WriteLine("\n===========================================");
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Display all available scripture references");
        Console.WriteLine("2. Randomly select a scripture to work on");
        Console.WriteLine("3. Add a new scripture to memorize");
        Console.WriteLine("4. Quit");
        Console.WriteLine("===========================================");
        Console.Write("What would you like to do? ");

        string userInput = Console.ReadLine().ToLower();
        int userChoice = 0;

        try
        {
            userChoice = int.Parse(userInput);
        }
        catch (FormatException)
        {
            userChoice = 0;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Unexpected error: {exception.Message}");
        }

        return userChoice;
    }
}

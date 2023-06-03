using System;
using System.Collections.Generic;

public class WordManager
{
    public string Words { get; set; }
    public string Reference { get; set; }
    public string[] WordList { get; private set; }
    public List<int> HiddenWords { get; private set; }

    public WordManager()
    {
    }

    public WordManager(string text, string visible)
    {

    }

    public void RenderWords(ScriptureManager scriptureManager)
    {
        Words = scriptureManager.CurrentScriptureText;
        WordList = Words.Split(" ");
        HiddenWords = new List<int>();
    }

    public void RenderReference(ScriptureManager scriptureManager)
    {
        // Implementation for rendering reference text
    }

    public void Show(string reference)
{
    Reference = reference;
    Console.Clear();
    Console.Write("\n**** Press spacebar or enter to hide words ****");
    Console.Write("\n**** Press Q to Quit ****\n");
    Console.WriteLine($"{Reference}");

    Console.WriteLine("\nSentence to Memorize:");

    for (int i = 0; i < WordList.Length; i++)
    {
        string word = WordList[i];
        int length = word.Length;
        string dashedLine = new String('_', length);

        if (HiddenWords.Contains(i))
        {
            Console.Write($"{dashedLine} ");
        }
        else
        {
            Console.Write($"{word} ");
        }
    }
}


    public void HandleUserInput()
{
    var input = Console.ReadKey();

    if (input.Key == ConsoleKey.Spacebar || input.Key == ConsoleKey.Enter)
    {
        GenerateNewHiddenWord();
    }
    else if (input.Key == ConsoleKey.Q)
    {
        Environment.Exit(1);
    }

    // Check if all words are hidden, and if not, continue to prompt for user input
    if (HiddenWords.Count < WordList.Length)
    {
        Show(Reference);
        HandleUserInput();
    }
}

    public void GenerateNewHiddenWord()
    {
        var random = new Random();
        var index1 = random.Next(WordList.Length);
        var index2 = random.Next(WordList.Length);

        if (HiddenWords.Contains(index1) || HiddenWords.Contains(index2))
        {
            GenerateNewHiddenWord();
        }
        else
        {
            HiddenWords.Add(index1);
            HiddenWords.Add(index2);
        }
    }
}
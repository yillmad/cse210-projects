using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ScriptureManager
{
    public List<Scripture> Scriptures { get; private set; }
    private string FileName { get; } = "DataText.txt";
    public int Index { get; private set; }
    public string CurrentScriptureText { get; private set; }

    public void LoadScriptures()
    {
        List<string> readText = File.ReadAllLines(FileName)
            .Where(arg => !string.IsNullOrWhiteSpace(arg))
            .ToList();

        Scriptures = new List<Scripture>();

        foreach (string line in readText)
        {
            string[] entries = line.Split(";");

            Scripture scripture = new Scripture();

            scripture.Key = entries[0];
            scripture.Text = entries[5];

            Scriptures.Add(scripture);
        }
    }

    public void DisplayScriptures()
{
    foreach (Scripture scripture in Scriptures)
    {
        // Split the scripture text by semicolons
        string[] parts = scripture.Text.Split(';');

        // Display the text starting from the 5th semicolon until the end
        for (int i = 4; i < parts.Length; i++)
        {
            Console.Write(parts[i].Trim());

            // Add a period at the end of each part except the last one
            if (i < parts.Length - 1)
            {
                Console.Write(". ");
            }
        }

        Console.WriteLine();
    }
}


    public int GetRandomIndex()
    {
        Random random = new Random();
        Index = random.Next(Scriptures.Count);
        return Index;
    }

    public string GetRandomScripture()
    {
        Index = GetRandomIndex();
        CurrentScriptureText = Scriptures[Index].Text;
        return CurrentScriptureText;
    }

    public class Scripture
    {
        public string Key { get; set; }
        public string Text { get; set; }

        public void Display()
        {
            Console.WriteLine($"\n{Text}");
        }
    }
}
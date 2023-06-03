using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ReferenceManager
{
    public List<Reference> References { get; private set; }
    private string FileName { get; } = "DataText.txt";

    public void LoadReferences()
    {
        List<string> readText = File.ReadAllLines(FileName)
            .Where(arg => !string.IsNullOrWhiteSpace(arg))
            .ToList();

        References = new List<Reference>();

        foreach (string line in readText)
        {
            string[] entries = line.Split(";");

            Reference reference = new Reference();

            reference.Key = entries[0];
            reference.Book = entries[1];
            reference.Chapter = int.Parse(entries[2]);
            reference.VerseStart = int.Parse(entries[3]);
            reference.VerseEnd = int.Parse(entries[4]);

            References.Add(reference);
        }
    }

    public void DisplayReferences()
    {
        foreach (Reference reference in References)
        {
            if (reference.VerseEnd == 0)
            {
                reference.DisplayReferenceOne();
            }
            else
            {
                reference.DisplayReferenceTwo();
            }
        }
    }

    public string GetReference(ScriptureManager scriptureManager)
    {
        int index = scriptureManager.Index;

        Reference reference = References[index];
        string referenceText;
        if (reference.VerseEnd == 0)
        {
            return referenceText = $"\n{reference.Book} {reference.Chapter}:{reference.VerseStart}";
        }
        else
        {
            return referenceText = $"\n{reference.Book} {reference.Chapter}:{reference.VerseStart}-{reference.VerseEnd}";
        }
    }

    public class Reference
    {
        public string Key { get; set; }
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int VerseStart { get; set; }
        public int VerseEnd { get; set; }

        public void DisplayReferenceOne()
        {
            Console.WriteLine($"\n{Book} {Chapter}:{VerseStart}");
        }

        public void DisplayReferenceTwo()
        {
            Console.WriteLine($"\n{Book} {Chapter}:{VerseStart}-{VerseEnd}");
        }
    }
}
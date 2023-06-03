using System;
using System.IO;

public class ScriptureEditor
{
    private string _fileName = "DataText.txt";

    public void AddNewScripture()
{
    Console.WriteLine("\n**** Add New Scripture ****");
    Console.WriteLine("Enter the details for the new scripture:");

    // Read the last key from the file and increment it by 1 to get the new key
    string lastKey = File.ReadLines(_fileName).LastOrDefault()?.Split(';')[0];
    int newKey = string.IsNullOrEmpty(lastKey) ? 1 : int.Parse(lastKey) + 1;
    string key = newKey.ToString();

    Console.Write("Book: ");
    string book = Console.ReadLine();

    Console.Write("Chapter: ");
    int chapter = Convert.ToInt32(Console.ReadLine());

    Console.Write("Verse Start: ");
    int verseStart = Convert.ToInt32(Console.ReadLine());

    Console.Write("Verse End (enter 0 if single verse): ");
    int verseEnd = Convert.ToInt32(Console.ReadLine());

    Console.Write("Scripture Text: ");
    string text = Console.ReadLine();

    Scripture newScripture = new Scripture()
    {
        Key = key,
        Book = book,
        Chapter = chapter,
        VerseStart = verseStart,
        VerseEnd = verseEnd,
        Text = text
    };

    SaveScripture(newScripture);
    Console.WriteLine("\nNew scripture has been added successfully.");
}

    private void SaveScripture(Scripture scripture)
    {
        using (StreamWriter writer = new StreamWriter(_fileName, true))
        {
            string entry = $"{scripture.Key};{scripture.Book};{scripture.Chapter};{scripture.VerseStart};{scripture.VerseEnd};{scripture.Text}";
            writer.WriteLine(entry);
        }
    }

    public class Scripture
    {
        public string Key { get; set; }
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int VerseStart { get; set; }
        public int VerseEnd { get; set; }
        public string Text { get; set; }
    }
}

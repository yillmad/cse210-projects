using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> ListNumbers = new List<int>();
        int Number = 0;
        do
        {
            Console.Write("EnterNumber: ");
            string Answer = Console.ReadLine();
            int IntAnswer = int.Parse(Answer);
            Number = IntAnswer;

            if(IntAnswer != 0)
            {
                ListNumbers.Add(IntAnswer);
            }

        }while(Number!=0);


        int sum = 0;
        foreach (int element in ListNumbers)
        {
            sum += element;
        } 
        Console.WriteLine($"The sum is: {sum}");


        float average = ((float)sum)/ListNumbers.Count;
        Console.WriteLine($"The average is: {average}");

        ListNumbers.Sort();
        int largestNumber=ListNumbers[ListNumbers.Count - 1];
        Console.WriteLine($"The largest number is: {largestNumber}");

        int smallestnumber = largestNumber;
        foreach(int order in ListNumbers)
        {
            if (order > 0 && order < smallestnumber)
            {
                smallestnumber=order;
            }
        }
        Console.WriteLine($"The smallest positive number is: {smallestnumber}");

    Console.WriteLine("The sorted list is: ");
        foreach (int answerNumber in ListNumbers)
        {
            Console.WriteLine(answerNumber);
        } 
    }
}
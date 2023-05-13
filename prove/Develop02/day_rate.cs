public class DayRating
{
    public int RateDay()
    {
        int rating = 0;

        Console.Write("Please rate your day on a scale of 1 to 10: ");
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out rating) && rating >= 1 && rating <= 10)
            {
                break;
            }
            Console.Write("Invalid rating. Please enter a number between 1 and 10: ");
        }

        return rating;
    }
}
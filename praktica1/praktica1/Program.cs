public class StringProcessor
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите строку:");
        string inputString = Console.ReadLine();
        string processedString = ProcessString(inputString);
        Console.WriteLine("Обработанная строка:");
        Console.WriteLine(processedString);
    }
    public static string ProcessString(string inputString)
    {
        if (inputString.Length % 2 == 0)
        {
            //Чётное количество символов
            int middle = inputString.Length / 2;
            string firstHalf = inputString.Substring(0, middle);
            string secondHalf = inputString.Substring(middle);
            return ReverseString(firstHalf) + ReverseString(secondHalf);
        }
        else
        {
            //Нечётное количество символов
            return ReverseString(inputString) + inputString;
        }
    }
    public static string ReverseString(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
        Console.ReadKey();
    }
}
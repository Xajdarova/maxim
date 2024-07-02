using System;
using System.Linq;
public class StringProcessor
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите строку:");
        string inputString = Console.ReadLine();

        // Проверка строки на наличие только букв английского алфавита в нижнем регистре
        if (!inputString.All(char.IsLower) || !inputString.All(char.IsLetter))
        {
            Console.WriteLine("Ошибка: В строке присутствуют недопустимые символы.");
            Console.WriteLine("Недопустимые символы:");
            foreach (char c in inputString.Where(c => !char.IsLetter(c) || !char.IsLower(c)))
            {
                Console.Write(c + " ");
            }
        }
        else
        {
            string processedString = ProcessString(inputString);
            Console.WriteLine("Обработанная строка:");
            Console.WriteLine(processedString);
        }
    }

    public static string ProcessString(string inputString)
    {
        if (inputString.Length % 2 == 0)
        {
            // Чётное количество символов
            int middle = inputString.Length / 2;
            return new string(inputString.Substring(0, middle).Reverse().ToArray()) +
                   new string(inputString.Substring(middle).Reverse().ToArray());
        }
        else
        {
            // Нечётное количество символов
            return new string(inputString.Reverse().ToArray()) + inputString;
        }
    }
}

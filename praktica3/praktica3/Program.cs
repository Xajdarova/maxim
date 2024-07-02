using System;
using System.Linq;
using System.Collections.Generic;

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

            // Подсчет повторов символов в обработанной строке
            Dictionary<char, int> symbolCounts = CountSymbolOccurrences(processedString);

            Console.WriteLine("Количество повторов символов:");
            foreach (KeyValuePair<char, int> pair in symbolCounts)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
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
    // Функция для подсчета повторов символов
    public static Dictionary<char, int> CountSymbolOccurrences(string str)
    {
        Dictionary<char, int> counts = new Dictionary<char, int>();

        foreach (char c in str)
        {
            if (counts.ContainsKey(c))
            {
                counts[c]++;
            }
            else
            {
                counts[c] = 1;
            }
        }

        return counts;
    }
}

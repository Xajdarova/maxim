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

            // Поиск самой длинной подстроки, начинающейся и заканчивающейся на гласную
            string longestSubstring = FindLongestVowelSubstring(processedString);

            if (longestSubstring != "")
            {
                Console.WriteLine("Самая длинная подстрока, начинающаяся и заканчивающаяся на гласную:");
                Console.WriteLine(longestSubstring);
            }
            else
            {
                Console.WriteLine("В обработанной строке нет подстрок, начинающихся и заканчивающихся на гласную.");
            }

            // Выбор алгоритма сортировки
            Console.WriteLine("Выберите алгоритм сортировки: 1 - Quicksort, 2 - Tree sort");
            int sortAlgorithm = Convert.ToInt32(Console.ReadLine());

            if (sortAlgorithm == 1)
            {
                string sortedString = Quicksort(processedString);
                Console.WriteLine("Отсортированная обработанная строка (Quicksort):");
                Console.WriteLine(sortedString);
            }
            else if (sortAlgorithm == 2)
            {
                string sortedString = TreeSort(processedString);
                Console.WriteLine("Отсортированная обработанная строка (Tree sort):");
                Console.WriteLine(sortedString);
            }
            else
            {
                Console.WriteLine("Некорректный выбор алгоритма сортировки.");
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

    // Реализация Quicksort
    public static string Quicksort(string input)
    {
        char[] array = input.ToCharArray();
        QuickSort(array, 0, array.Length - 1);
        return new string(array);
    }

    private static void QuickSort(char[] array, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(array, low, high);

            QuickSort(array, low, pi - 1);
            QuickSort(array, pi + 1, high);
        }
    }
    
    private static int Partition(char[] array, int low, int high)
    {
        char pivot = array[high];
        int i = (low - 1);

        for (int j = low; j <= high - 1; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
        (array[i + 1], array[high]) = (array[high], array[i + 1]);
        return (i + 1);
    }
    

    // Реализация Tree sort 
    public static string TreeSort(string input)
    {
        TreeNode root = null;
        foreach (char c in input)
        {
            root = Insert(root, c);
        }

        List<char> sortedList = new List<char>();
        InOrderTraversal(root, sortedList);
        return new string(sortedList.ToArray());
    }

    // Вспомогательные функции для TreeSort
    private static TreeNode Insert(TreeNode node, char value)
    {
        if (node == null)
        {
            return new TreeNode(value);
        }

        if (value < node.Value)
        {
            node.Left = Insert(node.Left, value);
        }
        else
        {
            node.Right = Insert(node.Right, value);
        }
        return node;
    }

    private static void InOrderTraversal(TreeNode node, List<char> sortedList)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left, sortedList);
            sortedList.Add(node.Value);
            InOrderTraversal(node.Right, sortedList);
        }
    }

    // Класс узла для бинарного дерева поиска
    private class TreeNode
    {
        public char Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(char value)
        {
            Value = value;
            Left = null;
            Right = null;
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

    // Функция для поиска самой длинной подстроки, начинающейся и заканчивающейся на гласную
    public static string FindLongestVowelSubstring(string str)
    {
        string longestSubstring = "";
        int maxLength = 0;

        for (int i = 0; i < str.Length; i++)
        {
            for (int j = i + 1; j <= str.Length; j++)
            {
                string substring = str.Substring(i, j - i);

                // Проверка, начинается ли и заканчивается ли подстрока на гласную
                if (IsVowel(substring[0]) && (substring.Length > 1 && IsVowel(substring[substring.Length - 1])) && substring.Length > maxLength)
                {
                    longestSubstring = substring;
                    maxLength = substring.Length;
                }
            }
        }

        return longestSubstring;
    }
    public static bool IsVowel(char c)
    {
        return "aeiouy".Contains(c);
    }
    
}
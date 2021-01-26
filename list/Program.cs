using System;
using System.Collections.Generic;

namespace list
{
    class Program
    {
        static void Main(string[] args)
        {
            //списки
            List<int> list = new List<int>();
            list.Add(0); //метод используется для добавления нескольких элементов
            list.Add(2);
            list.Add(3);
            list.Insert(1, 1); //метод используется для вставки нового элемента в середину списка
            list.RemoveAt(0); //удаляет элемент по индексу
            list.Remove(0); //метод используется для удаления первого экземпляра повторяющегося элемента, добавленного ранее
            list.Reverse(); //переворачивает список
            foreach (var e in list)
                Console.WriteLine(e);

            //словари
            var dictionary = new Dictionary<string, int>();
            Dictionary<string, int> dictionary1 = new Dictionary<string, int>();

            //дан массив строк, подсчитать для каждой строки количество вхождений
            var array = new[] { "A", "AB", "B", "A", "B", "B" };
            foreach (var e in array)
            {
                if (!dictionary.ContainsKey(e)) dictionary[e] = 0;
                dictionary[e]++;
            }
            foreach (var e in dictionary)
            {
                Console.WriteLine(e.Key + "\t" + e.Value); // выведет A 2 AB 1 B 3
            }

            //строки
            string str = "abc";
            //У строки есть методы
            Console.WriteLine(str.Substring(1, 2)); //bc
            Console.WriteLine(str.ToUpper()); //ABC

        }

        //выписать все слова, начинающиеся с большой буквы, в порядке обратном тому, как они встречались в тексте
        static string DecodeMessage(string[] lines)
        {
            List<string> list = new List<string>();
            foreach (string line in lines)
                if (!string.IsNullOrEmpty(line))
                    foreach (string word in line.Split(' ')) //разбиениe строки на слова 
                    {
                        if (char.IsUpper(word[0]))
                            list.Add(word);
                    }
            list.Reverse();
            return string.Join(" ", list.ToArray()); //Склеить отдельные слова в текст методом Join
        }

        //словарь, в котором по двум первым буквам имени можно найти все email из дневника записей вида <name>:<email>
        static Dictionary<string, List<string>> OptimizeContacts(List<string> contacts)
        {
            var dictionary = new Dictionary<string, List<string>>();
            foreach (var e in contacts)
            {
                var name = e.Split(':'); //Разбить запись на имя и email
                var key = name[0].Substring(0, Math.Min(2, name[0].Length));
                if (!dictionary.ContainsKey(key)) //проверка наличия ключа в словаре перед добавлением
                    dictionary[key] = new List<string>();
                dictionary[key].Add(e);
            }
            return dictionary;
        }

        //вернуть массив чисел, в котором на i-ой позиции находится статистика для цифры i
        static void Main1()
        {
            Console.WriteLine(GetBenfordStatistics("1")); //0, 1, 0, 0, 0, 0, 0, 0, 0, 0
            Console.WriteLine(GetBenfordStatistics("abc")); //0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            //PrintNumbers(GetBenfordStatistics("123 456 789"));
            Console.WriteLine(GetBenfordStatistics("abc 123 def 456 gf 789 i")); //0, 1, 0, 0, 1, 0, 0, 1, 0, 0
        }
        static int[] GetBenfordStatistics(string text)
        {
            var statistics = new int[10];
            for (int i = 0; i < statistics.Length; i++)
            {
                string[] words = text.Split(new char[] { ' ' });
                foreach (var word in words)
                {
                    var num = word[0] - '0';
                    if (num == i)
                        statistics[i]++;
                }
            }
            return statistics;
        }

        //заменить все встречающиеся в скопированном тексте разделители — пробелы, двоеточия, тире и т.п. на символ табуляции \t
        public static void Main2(string[] args)
        {
            Console.WriteLine(ReplaceIncorrectSeparators(sctext));
        }
        static string ReplaceIncorrectSeparators(string text)
        {
            string answer = string.Join("\t", text.Split(new char[] { ';', ':', ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries));
            return answer;
            //return text.Replace(": ", "\t").Replace("; ", "\t").Replace(" - ", "\t").Replace(", ", "\t").Replace(" ", "\t");
        }

    }
}

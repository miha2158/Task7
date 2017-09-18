using System;
using System.Collections.Generic;
using System.Text;

using static System.Console;

namespace Task7
{
    class Program
    {
        static string CheckInput(string input)
        {
            if (input.Length <= 1)
                return "Слишком короткая функция";

            bool p = false;
            foreach (char c in input)
                if (!(c == '0' || c == '1' || c == '*'))
                {
                    p = true;
                    break;
                }
            if (p)
                return "Ошибка. Возможные символы: '0', '1', '*'.";

            double value = Math.Log(input.Length, 2);
            if ((int)value != value)
                return "Булева функция должна иметь длину равную степени двойки";
            return null;
        }
        static StringBuilder[] FillString(string input)
        {
            int starCount = 0;
            foreach (char c in input)
                if (c == '*')
                    starCount++;

            var strings = new StringBuilder[(int)Math.Pow(2, starCount)];
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = new StringBuilder(input);

                string p = Convert.ToString(i, 2);
                int pl = p.Length;
                for (int l = 0; l < starCount - pl; l++)
                    p = "0" + p;
                for (int j = 0, k = 0; j < strings[i].Length; j++)
                {
                    if (strings[i][j] == '*')
                        strings[i][j] = p[k++];
                }
            }
            return strings;
        }
        static List<string> CheckValid(StringBuilder[] strings)
        {
            List<string> validStrings = new List<string>(0);
            foreach (StringBuilder s in strings)
            {
                bool p = true;
                for (int i = 0; i < s.Length / 2; i++)
                    if (s[i] == s[s.Length - 1 - i])
                    {
                        p = false;
                        break;
                    }

                if (!p)
                    validStrings.Add(s.ToString());
            }
            return validStrings;
        }

        static void Main(string[] args)
        {
            string input;
            WriteLine("Введите булеву функцию. Возможные символы: '0', '1', '*'.");
            WriteLine("Функция будет доопределена как НЕ самодвойственная");

            while (true)
            {
                input = ReadLine();
                string p = CheckInput(input);
                if(p == null)
                    break;
                WriteLine(p);
            }
            WriteLine();

            var allStrings = new[] { new StringBuilder(input) };
            if(!input.Contains("*"))
                WriteLine("Функция уже определена");
            else
                allStrings = FillString(input);

            var validStrings = CheckValid(allStrings);
            WriteLine(validStrings.Count == 0
                ? "Эту функцию нельзя доопределить как НЕ самодвойственную"
                : string.Join("\n", validStrings));

            ReadKey(true);
        }
    }
}
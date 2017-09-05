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
            return string.Empty;
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
                if(p == string.Empty)
                    break;
                WriteLine(p);
            }
            WriteLine();

            var allStrings = new[] { new StringBuilder(input) };
            if(!input.Contains("*"))
                WriteLine("Функция уже определена");
            else
            {
                int starCount = 0;
                foreach (char c in input)
                    if (c == '*')
                        starCount++;

                allStrings = new StringBuilder[(int)Math.Pow(2,starCount)];
                for (int i = 0; i < allStrings.Length; i++)
                {
                    allStrings[i] = new StringBuilder(input);

                    string p = Convert.ToString(i, 2);
                    int pl = p.Length;
                    for (int l = 0; l < starCount - pl; l++)
                        p = "0" + p;
                    for (int j = 0, k = 0; j < allStrings[i].Length; j++)
                    {
                        if (allStrings[i][j] == '*')
                            allStrings[i][j] = p[k++];

                    }
                }
            }

            List<string> validStrings = new List<string>(0);
            foreach (StringBuilder s in allStrings)
            {
                bool p = true;
                for (int i = 0; i < s.Length/2; i++)
                    if (s[i] == s[s.Length - 1 - i])
                    {
                        p = false;
                        break;
                    }

                if(!p)
                    validStrings.Add(s.ToString());
            }

            if(validStrings.Count == 0)
                WriteLine("Эту функцию нельзя доопределить как НЕ самодвойственную");
            else
            {
                WriteLine(string.Join("\n",validStrings));
            }
            ReadKey(true);
        }
    }
}

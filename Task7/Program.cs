using System;

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
                if (c != '0' || c != '1' || c != '*')
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

            while (true)
            {
                input = ReadLine();
                string p = CheckInput(input);
                if(p == string.Empty)
                    break;
                WriteLine(p);
            }






        }
    }
}

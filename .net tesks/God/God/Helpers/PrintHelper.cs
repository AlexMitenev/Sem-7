using System;
namespace God
{
    internal sealed class PrintHelper
    {
        public void PrintHuman(Human human)
        {
            if (human == null)
            {
                return;
            }

            Console.ForegroundColor = human.PrintColour;
            Console.Write(human.ToString());

            var coolParent = human as CoolParent;
            if (coolParent != null)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(coolParent.MoneyCount.ToString("C"));
            }
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintPair(Human pair)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            PrintHuman(pair);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void PrintColourInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Классные родители будут напечатаны голубым цветом");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Студенты будут напечатаны красным цветом");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ботаны будут напечатаны желтым цветом");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Родители будут напечатаны зеленым цветом");

            Console.WriteLine(string.Empty);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Суммарные деньги классных родителей будут выведены в файл TotalMoney.txt,");
            Console.WriteLine("который будет находится в той же папке, что и исполняемый файл");

            Console.WriteLine(string.Empty);
        }
    }
}

using System;

namespace AdvancedGod
{
    class PrinterHelper
    {
        private const string answer = "{0} человеку {1}нравится {2} человек";
        private const string child = "Ребенок";
        private const string separator = "! ";

        public void PrintLikes(bool isFirstLikeSecond, bool isSecondLikeFirst)
        {
            Console.ForegroundColor = isFirstLikeSecond ? ConsoleColor.Red : ConsoleColor.Blue;
            Console.WriteLine(answer, "Первому", isFirstLikeSecond ? "" : "не ", "второй");

            Console.ForegroundColor = isSecondLikeFirst ? ConsoleColor.Red : ConsoleColor.Blue;
            Console.WriteLine(answer, "Второму", isSecondLikeFirst ? "" : "не ", "первый");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintHuman(Human human)
        {
            if (human == null) return;
            Console.WriteLine(human.ToString());
        }

        public void PrintChild(IHasName obj)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(child + separator + obj.ToString());
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintExeption(string ex)
        {
            if (ex == null) return;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(ex);
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

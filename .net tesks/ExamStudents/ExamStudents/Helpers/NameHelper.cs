using System;
using System.Collections.Generic;

namespace ExamStudents
{
    internal sealed class NameHelper
    {
        private static readonly List<string> FirstNames =
            new List<string>{
                "Иван", 
                "Семен",
                "Евгений",
                "Владислав",
                "Константин",
                "Юрий"
            };

        private static readonly List<string> LastNames =
            new List<string> { 
                "Иванов",
                "Семенов",
                "Козлов", 
                "Котов", 
                "Ежиков", 
                "Кривокосин", 
                "Пушкин", 
                "Набоков",
                "Романов", 
                "Герасимов"
            };

        private static readonly Random Rnd = new Random();

        public static string GetName()
        {
            var separator = " ";
            var firstNameNumber = Rnd.Next(0, FirstNames.Count);
            var firstName = FirstNames[firstNameNumber];

            var lastNameNumber = Rnd.Next(0, LastNames.Count);
            var lastName = LastNames[lastNameNumber];

            return firstName + separator + lastName;
        }
    }
}

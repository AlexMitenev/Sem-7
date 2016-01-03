using System;
using System.Collections.Generic;

namespace AdvancedGod
{
    internal sealed class NameHelper
    {
        private readonly Random rand = new Random();
        private static readonly List<string> _manNames = new List<string>{"Виктор", "Семен", "Владимир", "Артем", "Петр"};
        private static readonly List<string> _womanNames = new List<string> { "Виктория", "Анастасия", "Кристина", "Елена", "Мария" };
        private static readonly List<string> _lastNames = new List<string> { "Козлов", "Смирнов", "Семенов", "Баранов", "Думов" };

        private const string womanLastNameEnd = "а";
        private const string separator = " ";
        private const string defaultName = "Unknown";

        private const string manPatronomicEnd = "ович";
        private const string womanPatronomicEnd = "овна";

        public string getPatronomic(Sex sex, string fatherName = null)
        {
            string end = sex == Sex.Man ? manPatronomicEnd : womanPatronomicEnd;
            if (!String.IsNullOrEmpty(fatherName) && _manNames.Contains(fatherName))
            {
                return fatherName + end;
            }
            else
            {
                var firstNameIndex = rand.Next(0, _manNames.Count);
                var firstName = _manNames[firstNameIndex];
                return firstName + end;
            }
        }

        public string GetHumanName(Sex sex, string fathername = null)
        {
            if (sex == Sex.NotKnown)
            {
                return defaultName;
            }

            var firstName = string.Empty;
            var patronomic = string.Empty;

            var nameList = sex == Sex.Man ? _manNames : _womanNames;
            var firstNameIndex = rand.Next(0, nameList.Count);
            firstName = nameList[firstNameIndex];

            if (fathername != null)
            {
                var nameAndPatronomic = fathername.Split();
                var fatherFirstName = nameAndPatronomic[0];
                patronomic = getPatronomic(sex, fatherFirstName);
            }
            else
            {
                patronomic = getPatronomic(sex);
            }

            return firstName + separator + patronomic;
        }
    }
}

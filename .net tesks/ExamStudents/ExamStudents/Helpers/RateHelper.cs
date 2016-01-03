using System;

namespace ExamStudents
{
    internal sealed class RateHelper
    {
        private const int MinRate = 2;
        private const int MaxRate = 5;
        private static readonly Random Rnd = new Random();

        public static int GetRateForStudent()
        {
            return Rnd.Next(MinRate, MaxRate + 1);
        }
    }
}

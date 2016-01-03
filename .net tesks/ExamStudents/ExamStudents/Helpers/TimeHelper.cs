using System;

namespace ExamStudents
{
    internal sealed class TimeHelper
    {
        public const int MaxTimeForStudentWait = 5000;
        public const int MaxTimeToWaitRate = 3000;

        private readonly Random rnd = new Random();
        public int GetRandomTime(int maxTime)
        {
            return rnd.Next(0, maxTime);
        }
    }
}

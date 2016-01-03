using System;

namespace ExamStudents
{
    internal class StudentRateEventArgs : EventArgs
    {
        public int StudentRate { get; private set; }

        public StudentRateEventArgs(int rate)
        {
            this.StudentRate = rate;
        }
    }
}

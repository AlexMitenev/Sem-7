using System;

namespace ExamStudents
{
    internal class StudentNameEventArgs : EventArgs
    {
        public string StudentName { get; private set; }

        public StudentNameEventArgs(string name)
        {
            this.StudentName = name;
        }      
    }
}

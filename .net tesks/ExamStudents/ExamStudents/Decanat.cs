using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ExamStudents
{   
    internal sealed class Decanat 
    {
        private readonly ManualResetEvent _handleExamStart = new ManualResetEvent(false);
        private readonly object _ExamLock = new object();
        private const int StudentCount = 15;

        public ManualResetEvent HandleExamStart
        {
            get { return _handleExamStart; }         
        }

        public event EventHandler StudentStartTakeAnExam;
        public event EventHandler StudentGetARate;
        public event EventHandler ExamIsEnd;

        public void Init()
        {
            Task[] tasks = new Task[StudentCount];
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < StudentCount; i++)
            {
                Student stud = new Student(this, i);
                var studTask = Task.Factory.StartNew(() => stud.PassExam());
                tasks[i] = studTask;
            }

            Task.Factory.StartNew(() => StartExam());
            Task.Factory.StartNew(() => PrintExamEnd(tasks));
        }

        public void TakeExam(Student student)
        {
            lock (_ExamLock)
            {
                EventHandler studentStartTakeAnExam = StudentStartTakeAnExam;
                if (studentStartTakeAnExam != null)
                {
                    var studentNameArgs = new StudentNameEventArgs(student.Name);
                    studentStartTakeAnExam(this, studentNameArgs);
                }

                Thread.Sleep(3000);

                var rate = RateHelper.GetRateForStudent();
                EventHandler studentGetARate = StudentGetARate;
                if (studentGetARate != null)
                {
                    var studentRateArgs = new StudentRateEventArgs(rate);
                    studentGetARate(this, studentRateArgs);
                }
            }
        }

        private void StartExam()
        {
            HandleExamStart.Set();
        }

        private void PrintExamEnd(Task[] tasks)
        {
            Task.WaitAll(tasks);

            //Rise event: exam is end!
            EventHandler examIsEnd = ExamIsEnd;
            if (examIsEnd != null)
            {
                examIsEnd(this, new EventArgs());
            }
        }
    }
}

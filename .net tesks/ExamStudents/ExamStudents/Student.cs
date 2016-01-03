using System.Threading;

namespace ExamStudents
{
    internal sealed class Student
    {
        private readonly Decanat _decanat;
        private TimeHelper timeHelper = new TimeHelper();

        public int Number { get; private set; }
        public string Name { get; private set; }      

        public Student(Decanat dec, int numberOfStudent)
        {
            Name = NameHelper.GetName();
            _decanat = dec;
            Number = numberOfStudent;
        } 

        public void PassExam()
        {
            _decanat.HandleExamStart.WaitOne();

            var time = timeHelper.GetRandomTime(TimeHelper.MaxTimeForStudentWait);
            Thread.Sleep(time);

            _decanat.TakeExam(this);
        }
    }
}

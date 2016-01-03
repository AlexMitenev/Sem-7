namespace ExamStudents
{
    internal interface IExamForm
    {
        void AddStudentNameToList(string studentName);
        void AddRateToStudent(int rate);
        void ExamEnd();
        void SetController(ExamController controller);
    }
}

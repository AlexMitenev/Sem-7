using System;

namespace ExamStudents
{
    internal sealed class ExamController
    {
        private IExamForm _form;
        private Decanat _decanat;

        public ExamController(IExamForm form, Decanat decanat)
        {
            _form = form;
            _decanat = decanat;
            form.SetController(this);
            SubscribeToModel();
        }

        public void SubscribeToModel()
        {
            _decanat.StudentStartTakeAnExam += new EventHandler(OnStudentStartTakeAnExam);
            _decanat.StudentGetARate += new EventHandler(OnStudentGetARate);
            _decanat.ExamIsEnd += new EventHandler(OnExamIsEnd);
        }

        internal void StartExam()
        {
            _decanat.Init();
        }

        private void OnStudentStartTakeAnExam(object sender, EventArgs e)
        {
            if (sender == null || e == null)
            {
                return;
            }
            var studNameArgs = e as StudentNameEventArgs;
            if (studNameArgs == null)
            {
                return;
            }
            _form.AddStudentNameToList(studNameArgs.StudentName);
        }

        private void OnStudentGetARate(object sender, EventArgs e)
        {
            if (sender == null || e == null)
            {
                return;
            }
            var studRateArgs = e as StudentRateEventArgs;
            if (studRateArgs == null)
            {
                return;
            }
            _form.AddRateToStudent(studRateArgs.StudentRate);
        }

        public void OnExamIsEnd(object sender, EventArgs e)
        {
            if (sender == null || e == null)
            {
                return;
            }
            _form.ExamEnd();
        }
    }
}

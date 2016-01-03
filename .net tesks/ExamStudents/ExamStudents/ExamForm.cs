using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamStudents
{
    internal partial class ExamForm : Form, IExamForm
    {
        private const string ReadyToExam = "Все готово к экзамену! Нажмите кнопку \"Начать\"!";
        private const string ExamNow = "Идет экзамен!!";
        private const string ExamEndString = "Экзамен завершен";
        private ExamController examController;

        public void SetController(ExamController controller)
        {
            examController = controller;
        }

        public static void InvokeIfRequired(Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => action()));
            }
            else
            {
                action();
            }
        }

        public ExamForm()
        {
            InitializeComponent();
            InitControlsValues();
        }

        public void AddStudentNameToList(string studentName)
        {
            var item = new ListViewItem(studentName, 0);
            InvokeIfRequired(StudentsListView, () => StudentsListView.Items.Add(item));
        }

        public void AddRateToStudent(int rate)
        {
            var itemsCount = StudentsListView.Items.Count;
            var lastItem = StudentsListView.Items[itemsCount - 1];
            var rateString = rate.ToString();
            InvokeIfRequired(StudentsListView, () => lastItem.SubItems.Add(rateString));
        }

        public void ExamEnd()
        {
            InvokeIfRequired(infoLabel, () => infoLabel.Text = ExamEndString);
            InvokeIfRequired(StartExamBtn, () => StartExamBtn.Enabled = true);
        }

        private void InitControlsValues()
        {
            infoLabel.Text = ReadyToExam;
        }      

        private void StartExamBtnClick(object sender, EventArgs e)
        {
            if (sender == null || e == null)
            {
                return;
            }

            InvokeIfRequired(infoLabel, () => infoLabel.Text = ExamNow);
            InvokeIfRequired(StartExamBtn, () => StartExamBtn.Enabled = false);
            InvokeIfRequired(StudentsListView, () => StudentsListView.Items.Clear());

            examController.StartExam();
        }
    }
}

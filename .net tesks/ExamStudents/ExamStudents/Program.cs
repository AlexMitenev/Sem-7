using System;
using System.Windows.Forms;

namespace ExamStudents
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var model = new Decanat();
            var form = new ExamForm();              
            var controller = new ExamController(form, model);
            
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form);
        }
    }
}

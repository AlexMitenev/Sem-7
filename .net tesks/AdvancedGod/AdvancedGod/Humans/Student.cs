using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedGod
{
    [Couple(Pair = "Girl", Probability = 0.7, ChildType = "Girl")]
    [Couple(Pair = "PrettyGirl", Probability = 1, ChildType = "PrettyGirl")]
    [Couple(Pair = "SmartGirl", Probability = 0.5, ChildType = "Girl")]   
    internal class Student : Human
    {
        private NameHelper nameHelper = new NameHelper();
        public Student(string name) : base(name)
        {
            Sex = Sex.Man;
            prefix = "Student: ";
        }

        public string GetChildName()
        {
            return nameHelper.GetHumanName(Sex.Woman, Name);
        }
    }
}

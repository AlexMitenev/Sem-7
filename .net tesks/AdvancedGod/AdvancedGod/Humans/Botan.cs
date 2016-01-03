using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedGod
{
    [Couple(Pair = "Girl", Probability = 0.7, ChildType = "SmartGirl")]
    [Couple(Pair = "PrettyGirl", Probability = 1, ChildType = "PrettyGirl")]
    [Couple(Pair = "SmartGirl", Probability = 0.8, ChildType = "Book")] 
    internal class Botan : Student
    {
        public Botan(string name) : base(name)
        {
            prefix = "Botan: ";
        }

        new public string GetChildName()
        {
            return base.GetChildName();
        }
    }
}

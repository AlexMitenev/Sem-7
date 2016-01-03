using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedGod
{
    [Couple(Pair = "Student", Probability = 0.02, ChildType = "Girl")]
    [Couple(Pair = "Botan", Probability = 0.05, ChildType = "Book")]
    internal sealed class SmartGirl : Girl
    {
        public SmartGirl(string name) : base(name)
        {
            prefix = "SmartGirl:";
        }
    }
}

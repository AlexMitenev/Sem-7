using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedGod
{
    [Couple(Pair = "Student", Probability = 0.04, ChildType = "PrettyGirl")]
    [Couple(Pair = "Botan", Probability = 0.01, ChildType = "PrettyGirl")]
    internal sealed class PrettyGirl : Girl
    {
        public PrettyGirl(string name) : base(name)
        {
            prefix = "PrettyGirl: ";
        }
    }
}

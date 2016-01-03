using System;
using System.Collections.Generic;

namespace AdvancedGod
{
    [Couple(Pair = "Student", Probability = 0.7, ChildType = "Girl")]
    [Couple(Pair = "Botan", Probability = 0.3, ChildType = "SmartGirl")]
    internal class Girl : Human
    {
        public Girl(string name) : base(name)
        {
            Sex = Sex.Woman;
            prefix = "Girl: ";
        }
    }
}

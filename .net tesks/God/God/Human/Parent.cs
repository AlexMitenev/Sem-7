using System;

namespace God
{
    internal class Parent : Human
    {
        public int ChildrenCount { get; private set; }
        public Parent(int childrenCount, string name, int age, Sex sex)
            : base(name, age, sex)
        {
            ChildrenCount = childrenCount > 0 ? childrenCount : 0;
            PrintColour = ConsoleColor.Green;
        }
        
        public override string ToString()
        {
            return base.ToString() + String.Format(", Количество детей: {0}", ChildrenCount);
        }
    }
}

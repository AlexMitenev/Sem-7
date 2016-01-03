using System;
using System.Collections.Generic;

namespace AdvancedGod
{
    internal class Human : IHasName
    {
        protected string prefix = "Human: ";
        private NameHelper nameHelper = new NameHelper();

        public Sex Sex { get; protected set; }
        public string Name { get; protected set; }
        public string Patronomic { get; protected set; }
        

        public Human(string name)
        {
            Sex = Sex.NotKnown;
            Name = name;
        }

        public override string ToString()
        {
            return prefix + Name;
        }
    }
}

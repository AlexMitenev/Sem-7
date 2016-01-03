using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedGod
{
    internal class Book : IHasName
    {
        private string prefix = "Book: ";

        public string Name { get; private set; }
        public Book(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return prefix + Name;
        }
    }
}

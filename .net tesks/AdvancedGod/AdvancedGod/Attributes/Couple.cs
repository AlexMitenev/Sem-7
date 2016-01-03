namespace AdvancedGod
{
    using System;
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    internal sealed class Couple : System.Attribute
    {
        public string Pair { get; set; }
        public double Probability { get; set; }
        public string ChildType { get; set; }
    }
}

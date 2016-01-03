using System;

namespace AdvancedGod
{
    internal sealed class HomosexualityException : Exception
    {
        public HomosexualityException ()
        {
        }

        public HomosexualityException (string message) : base(message)
        {
        }

        public HomosexualityException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

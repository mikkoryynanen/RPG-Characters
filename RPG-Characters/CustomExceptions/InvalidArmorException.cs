using System;

namespace RPG_Characters.CustomExceptions
{
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException(string message) : base(message)
        {
        }
    }
}

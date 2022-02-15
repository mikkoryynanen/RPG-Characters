using System;

namespace RPG_Characters.CustomExceptions
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message) : base(message)
        {
        }
    }
}

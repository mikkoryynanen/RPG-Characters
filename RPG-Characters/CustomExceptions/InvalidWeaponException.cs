using System;

namespace RPG_Characters.CustomExceptions
{
    public class InvalidWeaponException : Exception
    {
        //public override string Message => base.Message;
        public InvalidWeaponException(string message) : base(message)
        {
        }
    }
}

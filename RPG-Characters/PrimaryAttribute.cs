using System;
namespace RPGCharacters
{
    public class PrimaryAttribute
    {
        public int Value { get; private set; }
        //static public PrimaryAttribute operator +(PrimaryAttribute pa) => pa;

        public PrimaryAttribute(int value)
        {
            this.Value = value;
        }

        public void Add(int val)
        {
            Value += val;
        }
    }
}

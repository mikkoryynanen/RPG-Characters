using System;
namespace RPG_Characters
{
    public class PrimaryAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        //static public PrimaryAttribute operator +(PrimaryAttribute pa) => pa;

        //public PrimaryAttribute(Stren)
        //{
        //    this.Value = value;
        //}

        public void Add(PrimaryAttributes attributes)
        {
            Strength += attributes.Strength;
            Dexterity += attributes.Dexterity;
            Intelligence += attributes.Intelligence;
        }
    }
}

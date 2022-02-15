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

        /// <summary>
        /// Add given PrimaryAttributes to current values
        /// </summary>
        /// <param name="attributes">PrimaryAttributes object to add to current values</param>
        public void Add(PrimaryAttributes attributes)
        {
            Strength += attributes.Strength;
            Dexterity += attributes.Dexterity;
            Intelligence += attributes.Intelligence;
        }
    }
}

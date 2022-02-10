using System.Collections.Generic;

namespace RPGCharacters.Models.Items
{
    public class Armor : Item
    {
        public enum Type
        {
            Cloth,
            Leather,
            Mail,
            Plate
        }
        public Type ArmorType { get; private set; }
        public PrimaryAttribute Strength { get; private set; } = new PrimaryAttribute(0);
        public PrimaryAttribute Dexterity { get; private set; } = new PrimaryAttribute(0);
        public PrimaryAttribute Intelligence { get; private set; } = new PrimaryAttribute(0);

        public Armor(string name, int requiredlevel, Slot itemSlot, PrimaryAttribute[] attributes) : base(name, requiredlevel, itemSlot)
        {

        }
    }
}

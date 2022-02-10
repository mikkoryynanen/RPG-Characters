using System;
using System.Collections.Generic;

namespace RPGCharacters.Models.Items
{
    public class Armor : Item
    {
        [Flags]
        public enum Type
        {
            Cloth = 1,
            Leather = 2,
            Mail = 4,
            Plate = 8
        }
        public Type ArmorType { get; private set; }
        public PrimaryAttribute Strength { get; private set; } = new PrimaryAttribute(0);
        public PrimaryAttribute Dexterity { get; private set; } = new PrimaryAttribute(0);
        public PrimaryAttribute Intelligence { get; private set; } = new PrimaryAttribute(0);

        public Armor(string name, int requiredlevel, Slot itemSlot, Type armorType, PrimaryAttribute[] attributes) : base(name, requiredlevel, itemSlot)
        {
            ArmorType = armorType;
        }
    }
}

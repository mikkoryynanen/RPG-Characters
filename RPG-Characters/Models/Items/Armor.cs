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
        public PrimaryAttributes Attributes { get; private set; }

        public Armor(string name, int requiredlevel, Slot itemSlot, Type armorType, PrimaryAttributes attributes) : base(name, requiredlevel, itemSlot)
        {
            ArmorType = armorType;
            Attributes = attributes;
        }
    }
}

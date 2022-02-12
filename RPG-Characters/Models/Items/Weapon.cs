using System;
using RPG_Characters;

namespace RPG_Characters.Models.Items
{
    public class Weapon : Item
    {
        [Flags]
        public enum Type
        {
            Axe = 1,
            Bow = 2,
            Dagger = 4,
            Hammer = 8,
            Staff = 16,
            Sword = 32,
            Wand = 64
        }
        public Type WeaponType { get; private set; }
        private readonly WeaponAttributes Attributes;


        public Weapon(string name, int requiredlevel, int damage, float attackSpeed, Type weaponType) : base(name, requiredlevel, Slot.Weapon)
        {
            Attributes = new WeaponAttributes
            {
                Damage = damage,
                AttackSpeed = attackSpeed
            };
            WeaponType = weaponType;
        }

        public float GetDamagePerSecond()
        {
            return Attributes.Damage * Attributes.AttackSpeed;
        }
    }
}

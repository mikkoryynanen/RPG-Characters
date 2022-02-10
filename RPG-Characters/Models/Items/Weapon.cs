using System;

namespace RPGCharacters.Models.Items
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

        private readonly int _baseDamage;
        private readonly float _baseAttackSpeed;

        public Weapon(string name, int requiredlevel, int damage, float attackSpeed, Type weaponType) : base(name, requiredlevel, Slot.Weapon)
        {
            _baseDamage = damage;
            _baseAttackSpeed = attackSpeed;
            WeaponType = weaponType;
        }

        public float GetDamagePerSecond()
        {
            return _baseDamage * _baseAttackSpeed;
        }
    }
}

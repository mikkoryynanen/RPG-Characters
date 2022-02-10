namespace RPGCharacters.Models.Items
{
    public class Weapon : Item
    {
        public enum Type
        {
            Axe,
            Bow,
            Dagger,
            Hammer,
            Staff,
            Sword,
            Wand
        }
        public Type WeaponType { get; private set; }

        private readonly int _baseDamage;
        private readonly int _baseAttackSpeed;

        public Weapon(string name, int requiredlevel, int damage, int attackSpeed, Slot itemSlot) : base(name, requiredlevel, itemSlot)
        {
            _baseDamage = damage;
            _baseAttackSpeed = attackSpeed;
        }

        public int GetDamagePerSecond()
        {
            return _baseDamage * _baseAttackSpeed;
        }
    }
}

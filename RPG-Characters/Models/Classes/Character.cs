using System.Collections.Generic;
using RPG_Characters.CustomExceptions;
using RPG_Characters.Models.Items;
using static RPG_Characters.Models.Item;

namespace RPG_Characters.Models.Classes
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int Level { get; private set; } = 1;
        public PrimaryAttributes Attributes { get; private set; }

        protected List<PrimaryAttributes> _totalAttributesFromItems = new List<PrimaryAttributes>();
        private Dictionary<Slot, Item> _equippedItems = new Dictionary<Slot, Item>();

        private readonly int _maxLevel = 15;
        private readonly int _strengthPerLevel;
        private readonly int _dexterityPerLevel;
        private readonly int _intelligencePerLevel;
        private readonly Weapon.Type _allowedWeaponTypes;
        private readonly Armor.Type _allowedArmorTypes;


        public Character(string name, int baseStrength, int baseDexterity, int baseIntelligence, int strengthPerLevel, int dexterityPerLevel, int intelligencePerLevel, Weapon.Type allowedWeaponTypes, Armor.Type allowedArmorTypes)
        {
            Attributes = new PrimaryAttributes
            {
                Strength = baseStrength,
                Dexterity = baseDexterity,
                Intelligence = baseIntelligence
            };

            Name = name;
            _strengthPerLevel = strengthPerLevel;
            _dexterityPerLevel = dexterityPerLevel;
            _intelligencePerLevel = intelligencePerLevel;
            _allowedWeaponTypes = allowedWeaponTypes;
            _allowedArmorTypes = allowedArmorTypes;
        }

        public void LevelUp()
        {
            Attributes.Add(new PrimaryAttributes
            {
               Strength = _strengthPerLevel,
               Dexterity = _dexterityPerLevel,
               Intelligence = _intelligencePerLevel
            });

            Level = Level < _maxLevel ? Level + 1 : Level;
        }

        public string EquipItem(Item item)
        {
            bool isArmor = item is Armor;

            #region Error Check
            if (!isArmor)
            {
                if (!_allowedWeaponTypes.HasFlag(((Weapon)item).WeaponType))
                {
                    throw new InvalidWeaponException(string.Format("{0} class does not support weapon type {1}", Name, ((Weapon)item).WeaponType));
                }
                else if (item.RequiredLevel > Level)
                {
                    throw new InvalidWeaponException("Weapon equip failed, Level is too high");
                }
            }
            else
            {
                if (!_allowedArmorTypes.HasFlag(((Armor)item).ArmorType))
                {
                    throw new InvalidArmorException(string.Format("Failed to equip armor for {0}. {1} is not allowed type", Name, ((Armor)item).ArmorType));
                }
                else if (item.RequiredLevel > Level)
                {
                    throw new InvalidArmorException("Armor equip failed, Level is too high");
                }
            }
            #endregion

            _equippedItems.Add(item.ItemSlot, item);

            if (isArmor)
            {
                Armor armor = (Armor)item;
                _totalAttributesFromItems.Add(armor.Attributes);
            }

            return isArmor ? "New armor equipped!" : "New weapon equipped!";
        }

        protected float GetDamage(int totalAttributesFromItems, int totalAttributesFromLevel)
        protected float CalculateDamage(int totalAttributesFromItems, int totalAttributesFromLevel)
        {
            int totalAttributes = totalAttributesFromLevel + totalAttributesFromItems;
            float weaponDPS = HasItemInSlot(Slot.Weapon) ? ((Weapon)_equippedItems[Slot.Weapon]).GetDamagePerSecond() : 1f;

            return weaponDPS * (1 + totalAttributes / 100);
        }

        public bool HasItemInSlot(Slot slot)
        {
            return _equippedItems.ContainsKey(slot);
        }
    }
}

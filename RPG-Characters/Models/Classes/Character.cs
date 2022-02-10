using System;
using System.Collections.Generic;
using System.Linq;
using RPG_Characters.CustomExceptions;
using RPGCharacters.Models.Items;
using static RPGCharacters.Models.Item;

namespace RPGCharacters.Models.Classes
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int Level { get; private set; } = 1;

        private List<PrimaryAttribute> _totalStrengthAttributes = new List<PrimaryAttribute>();
        private List<PrimaryAttribute> _totalDexterityAttributes = new List<PrimaryAttribute>();
        private List<PrimaryAttribute> _totalIntelligenceAttributes = new List<PrimaryAttribute>();

        private Dictionary<Slot, Item> _equippedItems = new Dictionary<Slot, Item>();

        public PrimaryAttribute Strength { get; private set; }
        public PrimaryAttribute Dexterity { get; private set; }
        public PrimaryAttribute Intelligence { get; private set; }

        public readonly PrimaryAttribute BaseStrength;
        public readonly PrimaryAttribute BaseDexterity;
        public readonly PrimaryAttribute BaseIntelligence;
        private readonly int _maxLevel = 15;
        private readonly int _strengthPerLevel;
        private readonly int _dexterityPerLevel;
        private readonly int _intelligencePerLevel;
        private readonly Weapon.Type _allowedWeaponTypes;
        private readonly Armor.Type _allowedArmorTypes;


        public Character(string name, int baseStrength, int baseDexterity, int baseIntelligence, int strengthPerLevel, int dexterityPerLevel, int intelligencePerLevel, Weapon.Type allowedWeaponTypes, Armor.Type allowedArmorTypes)
        {
            BaseStrength =  new PrimaryAttribute(baseStrength);
            BaseDexterity = new PrimaryAttribute(baseDexterity);
            BaseIntelligence =  new PrimaryAttribute(baseIntelligence);

            Strength = new PrimaryAttribute(BaseStrength.Value);
            Dexterity = new PrimaryAttribute(BaseDexterity.Value);
            Intelligence = new PrimaryAttribute(BaseIntelligence.Value);

            Name = name;
            _strengthPerLevel = strengthPerLevel;
            _dexterityPerLevel = dexterityPerLevel;
            _intelligencePerLevel = intelligencePerLevel;
            _allowedWeaponTypes = allowedWeaponTypes;
            _allowedArmorTypes = allowedArmorTypes;
        }

        public virtual void LevelUp()
        {
            Strength.Add(_strengthPerLevel);
            Dexterity.Add(_dexterityPerLevel);
            Intelligence.Add(_intelligencePerLevel);

            Level = Level < _maxLevel ? Level + 1 : Level;
        }

        public void EquipItem(Item item)
        {
            if (item is Weapon)
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

            if (item is Armor)
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

        _equippedItems.Add(item.ItemSlot, item);

            if (item is Armor)
            {
                Armor armor = (Armor)item;
                if (armor.Strength.Value > 0)
                    _totalStrengthAttributes.Add(armor.Strength);
                if (armor.Dexterity.Value > 0)
                    _totalDexterityAttributes.Add(armor.Dexterity);
                if (armor.Intelligence.Value > 0)
                    _totalIntelligenceAttributes.Add(armor.Intelligence);
            }
        }

        public virtual float GetDamage()
        {
            // TODO: Fix this calculation to the correct one
            int totalStength = _totalDexterityAttributes.Sum(s => s.Value);
            float weaponDamage = ((Weapon)_equippedItems[Slot.Weapon]).GetDamagePerSecond();
            return totalStength + weaponDamage;
        }
    }
}

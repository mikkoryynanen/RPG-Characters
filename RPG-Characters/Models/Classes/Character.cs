using System.Collections.Generic;
using System.Linq;
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


        public Character(string name, int baseStrength, int baseDexterity, int baseIntelligence, int strengthPerLevel, int dexterityPerLevel, int intelligencePerLevel)
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
            // TODO: Throw InvalidArmorException upon failed ARMOR equip
            // TODO: Throw InvalidWeaponException upon failed WEAPON equip

            _equippedItems.Add(item.ItemSlot, item);

            if (item is Armor)
            {
                Armor armor = (Armor)item;
                if(armor.Strength.Value > 0)
                    _totalStrengthAttributes.Add(armor.Strength);
                if (armor.Dexterity.Value > 0)
                    _totalDexterityAttributes.Add(armor.Dexterity);
                if (armor.Intelligence.Value > 0)
                    _totalIntelligenceAttributes.Add(armor.Intelligence);
            }
        }

        public virtual int GetDamage()
        {
            // TODO: Fix this calculation to the correct one
            int totalStength = _totalDexterityAttributes.Sum(s => s.Value);
            int weaponDamage = ((Weapon)_equippedItems[Slot.Weapon]).GetDamagePerSecond();
            return totalStength + weaponDamage;
        }
    }
}

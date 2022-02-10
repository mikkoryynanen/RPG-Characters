using System;
using System.Linq;
using RPG_Characters.Models.Classes;

namespace RPGCharacters.Models.Classes
{
    public class Warrior : Character, IDamageable
    {
        public Warrior(string name = "Warrior")
            : base(
                  name,
                  baseStrength: 5, baseDexterity: 2, baseIntelligence: 1,
                  strengthPerLevel: 3, dexterityPerLevel: 2, intelligencePerLevel: 1,
                  allowedWeaponTypes: Items.Weapon.Type.Axe | Items.Weapon.Type.Hammer | Items.Weapon.Type.Sword,
                  allowedArmorTypes: Items.Armor.Type.Mail | Items.Armor.Type.Plate
                  )
        { 
        }

        public float GetCharacterDamage()
        {
            int totalAttributesFromItems = _totalAttributesFromItems.Sum(i => i.Strength);
            int totalAttributesFromLevel = Attributes.Strength;
            return base.GetDamage(totalAttributesFromItems, totalAttributesFromLevel);
        }

        public override void LevelUp()
        {
            base.LevelUp();
        }
    }
}

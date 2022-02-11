using System;
using System.Linq;
using RPGCharacters.Models.Classes;
using RPGCharacters.Models.Items;

namespace RPG_Characters.Models.Classes
{
    public class Mage : Character, IDamageable
    {
        public Mage()
            : base(
                  "Mage",
                  baseStrength: 1, baseDexterity: 1, baseIntelligence: 8,
                  strengthPerLevel: 1, dexterityPerLevel: 1, intelligencePerLevel: 5,
                  allowedWeaponTypes: Weapon.Type.Staff | Weapon.Type.Wand,
                  allowedArmorTypes: Armor.Type.Cloth
                  )
        {
        }

        public float GetCharacterDamage()
        {
            int totalAttributesFromItems = _totalAttributesFromItems.Sum(i => i.Intelligence);
            int totalAttributesFromLevel = Attributes.Intelligence;
            return base.GetDamage(totalAttributesFromItems, totalAttributesFromLevel);
        }
    }
}

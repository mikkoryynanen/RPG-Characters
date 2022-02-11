using System;
using System.Linq;
using System.Text;
using RPG_Characters.Misc;
using RPGCharacters.Models.Classes;
using RPGCharacters.Models.Items;

namespace RPG_Characters.Models.Classes
{
    public class Mage : Hero
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

        public override float GetCharacterDamage()
        {
            int totalAttributesFromItems = _totalAttributesFromItems.Sum(i => i.Intelligence);
            int totalAttributesFromLevel = Attributes.Intelligence;
            return GetDamage(totalAttributesFromItems, totalAttributesFromLevel);
        }

        public override void ShowStats()
        {
            Console.WriteLine(StatBuilder.GenerateStats(Name, Level, GetCharacterDamage(), Attributes));
        }
    }
}

using System;
using System.Linq;
using RPG_Characters.Misc;
using RPG_Characters.Models.Classes;
using RPG_Characters.Models.Items;

namespace RPG_Characters.Models.Classes
{
    public class Ranger : Hero
    {
        public Ranger()
            : base(
                  "Ranger",
                  baseStrength: 1, baseDexterity: 7, baseIntelligence: 1,
                  strengthPerLevel: 1, dexterityPerLevel: 5, intelligencePerLevel: 1,
                  allowedWeaponTypes: Weapon.Type.Bow,
                  allowedArmorTypes: Armor.Type.Leather | Armor.Type.Mail
                  )
        {
        }

        public override float GetCharacterDamage()
        {
            int totalAttributesFromItems = _totalAttributesFromItems.Sum(i => i.Dexterity);
            int totalAttributesFromLevel = Attributes.Dexterity;
            return base.CalculateDamage(totalAttributesFromItems, totalAttributesFromLevel);
        }

        public override void ShowStats()
        {
            Console.WriteLine(StatBuilder.GenerateStats(Name, Level, GetCharacterDamage(), Attributes));
        }
    }
}

using System;
using System.Linq;
using RPG_Characters.Misc;
using RPGCharacters.Models.Classes;
using RPGCharacters.Models.Items;

namespace RPG_Characters.Models.Classes
{
    public class Rogue : Hero
    {
        public Rogue()
            : base(
                  "Rogue",
                  baseStrength: 2, baseDexterity: 6, baseIntelligence: 1,
                  strengthPerLevel: 1, dexterityPerLevel: 4, intelligencePerLevel: 1,
                  allowedWeaponTypes: Weapon.Type.Dagger | Weapon.Type.Sword,
                  allowedArmorTypes: Armor.Type.Leather | Armor.Type.Mail
                  )
        {
        }

        public override float GetCharacterDamage()
        {
            int totalAttributesFromItems = _totalAttributesFromItems.Sum(i => i.Dexterity);
            int totalAttributesFromLevel = Attributes.Dexterity;
            return base.GetDamage(totalAttributesFromItems, totalAttributesFromLevel);
        }

        public override void ShowStats()
        {
            Console.WriteLine(StatBuilder.GenerateStats(Name, Level, GetCharacterDamage(), Attributes));
        }
    }
}

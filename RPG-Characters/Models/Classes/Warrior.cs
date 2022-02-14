using System;
using System.Linq;
using System.Text;
using RPG_Characters.Misc;
using RPG_Characters.Models.Classes;

namespace RPG_Characters.Models.Classes
{
    public class Warrior : Hero
    {
        public Warrior()
            : base(
                  "Warrior",
                  baseStrength: 5, baseDexterity: 2, baseIntelligence: 1,
                  strengthPerLevel: 3, dexterityPerLevel: 2, intelligencePerLevel: 1,
                  allowedWeaponTypes: Items.Weapon.Type.Axe | Items.Weapon.Type.Hammer | Items.Weapon.Type.Sword,
                  allowedArmorTypes: Items.Armor.Type.Mail | Items.Armor.Type.Plate
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

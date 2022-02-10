using System;
namespace RPGCharacters.Models.Classes
{
    public class Warrior : Character
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

        public override void LevelUp()
        {
            base.LevelUp();
        }
    }
}

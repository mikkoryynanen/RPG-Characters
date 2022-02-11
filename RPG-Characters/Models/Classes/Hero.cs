using System;
using System.Linq;
using System.Text;
using RPGCharacters.Models.Classes;
using RPGCharacters.Models.Items;

namespace RPG_Characters.Models.Classes
{
    public abstract class Hero : Character, IDamageable
    {
        public Hero(string name, int baseStrength, int baseDexterity, int baseIntelligence,
                  int strengthPerLevel, int dexterityPerLevel, int intelligencePerLevel, Weapon.Type allowedWeaponTypes, Armor.Type allowedArmorTypes)
            : base(
                  name,
                  baseStrength, baseDexterity, baseIntelligence,
                  strengthPerLevel, dexterityPerLevel, intelligencePerLevel,
                  allowedWeaponTypes, allowedArmorTypes
                  )
        {
        }

        public abstract float GetCharacterDamage();
        public abstract void ShowStats();
    }
}

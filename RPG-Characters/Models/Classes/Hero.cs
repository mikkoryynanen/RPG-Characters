using RPG_Characters.Models.Items;

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

        /// <summary>
        /// Gets the characters damage. Individual implemenation on each class due to main damage providing stat being different
        /// </summary>
        /// <returns>Calculated damage from character</returns>
        public abstract float GetCharacterDamage();
        /// <summary>
        /// Prints out the class stats to the cnosole
        /// </summary>
        public abstract void ShowStats();
    }
}

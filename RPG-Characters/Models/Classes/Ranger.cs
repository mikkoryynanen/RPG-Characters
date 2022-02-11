using System.Linq;
using RPGCharacters.Models.Classes;
using RPGCharacters.Models.Items;

namespace RPG_Characters.Models.Classes
{
    public class Ranger : Character, IDamageable
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

        public float GetCharacterDamage()
        {
            int totalAttributesFromItems = _totalAttributesFromItems.Sum(i => i.Dexterity);
            int totalAttributesFromLevel = Attributes.Dexterity;
            return base.GetDamage(totalAttributesFromItems, totalAttributesFromLevel);
        }
    }
}

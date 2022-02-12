using RPG_Characters.CustomExceptions;
using RPG_Characters;
using RPG_Characters.Models.Classes;
using RPG_Characters.Models.Items;
using Xunit;

namespace RPG_Characters_Tests
{
    public class RPGItemTests
    {
        [Fact]
        public void EquipItem_EquippingHighLevelWeapon_ShouldThrowInvalidWeaponExeption()
        {
            Warrior warrior = new Warrior();
            Weapon testAxe = new Weapon("Axe of testing", 2, 7, 1.1f, Weapon.Type.Axe);
            Assert.Throws<InvalidWeaponException>(() =>
            {
                warrior.EquipItem(testAxe);
            });
        }

        [Fact]
        public void EquipItem_EquippingHighLevelArmor_ShouldThrowInvalidArmorExeption()
        {
            Warrior warrior = new Warrior();
            Armor testArmor = new Armor("Armor of testing", 2, RPG_Characters.Models.Item.Slot.Body, Armor.Type.Cloth, new PrimaryAttributes
            {
                Intelligence = 5
            });

            Assert.Throws<InvalidArmorException>(() =>
            {
                warrior.EquipItem(testArmor);
            });
        }

        [Fact]
        public void EquipItem_EquipWrongWeaponType_ShouldThrowInvalidWeaponException()
        {
            Warrior warrior = new Warrior();
            Weapon weapon = new Weapon("Bow of testing", 1, 7, 1.1f, Weapon.Type.Bow);
            Assert.Throws<InvalidWeaponException>(() =>
            {
                warrior.EquipItem(weapon);
            });
        }

        [Fact]
        public void EquipItem_EquipWrongArmorType_ShouldThrowInvalidArmorException()
        {
            Warrior warrior = new Warrior();
            Armor testArmor = new Armor("Armor of testing", 1, RPG_Characters.Models.Item.Slot.Body, Armor.Type.Cloth, new PrimaryAttributes
            {
                Intelligence = 5
            });
            Assert.Throws<InvalidArmorException>(() =>
            {
                warrior.EquipItem(testArmor);
            });
        }

        [Fact]
        public void EquipItem_ArmorEquipMessage_ShouldShowMesssage()
        {
            string expectedMessage = "New armor equipped!";
            Warrior warrior = new Warrior();
            Armor testArmor = new Armor("Armor of testing", 1, RPG_Characters.Models.Item.Slot.Body, Armor.Type.Plate, new PrimaryAttributes
            {
                Strength = 1
            });
            Assert.Equal(expectedMessage, warrior.EquipItem(testArmor));
        }

        [Fact]
        public void EquipItem_WeaponEquipMessage_ShouldShowMesssage()
        {
            string expectedMessage = "New weapon equipped!";
            Warrior warrior = new Warrior();
            Weapon weapon = new Weapon("Axe of testing", 1, 7, 1.1f, Weapon.Type.Axe);
            Assert.Equal(expectedMessage, warrior.EquipItem(weapon));
        }

        [Fact]
        public void Damage_CalculateDamageWithoutWeapon_DamageWithoutWeapon()
        {
            float expectedDamage = 1 * (1 + (5 / 100));

            Warrior warrior = new Warrior();
            float actualDamage = warrior.GetCharacterDamage();

            Assert.Equal(expectedDamage, actualDamage);
        }

        [Fact]
        public void Damage_CalculateDamageWithWeapon_DamageWithWeapon()
        {
            float expectedDamage = (7 * 1.1f) * (1 + (5 / 100));

            Warrior warrior = new Warrior();
            Weapon weapon = new Weapon("Axe of testing", 1, 7, 1.1f, Weapon.Type.Axe);
            warrior.EquipItem(weapon);
            float actualDamage = warrior.GetCharacterDamage();

            Assert.Equal(expectedDamage, actualDamage);
        }

        [Fact]
        public void Damage_CalculateDamageWithWeaponAndArmor_DamageWithWeaponAndArmor()
        {
            float expectedDamage = (7 * 1.1f) * (1 + ((5 + 1) / 100));

            Warrior warrior = new Warrior();
            Weapon weapon = new Weapon("Axe of testing", 1, 7, 1.1f, Weapon.Type.Axe);
            Armor armor = new Armor("Armor of testing", 1, RPG_Characters.Models.Item.Slot.Body, Armor.Type.Plate, new PrimaryAttributes { Strength = 10 });

            warrior.EquipItem(armor);
            warrior.EquipItem(weapon);

            float actualDamage = warrior.GetCharacterDamage();

            Assert.Equal(expectedDamage, actualDamage);
        }
    }
}

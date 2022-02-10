using RPG_Characters.CustomExceptions;
using RPGCharacters;
using RPGCharacters.Models.Classes;
using RPGCharacters.Models.Items;
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
            Armor testArmor = new Armor("Armor of testing", 2, RPGCharacters.Models.Item.Slot.Body, Armor.Type.Cloth, new PrimaryAttribute[]
            {
                new PrimaryAttribute(1)
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
            Armor testArmor = new Armor("Armor of testing", 1, RPGCharacters.Models.Item.Slot.Body, Armor.Type.Cloth, new PrimaryAttribute[]
            {
                new PrimaryAttribute(1)
            });
            Assert.Throws<InvalidArmorException>(() =>
            {
                warrior.EquipItem(testArmor);
            });
        }
    }
}

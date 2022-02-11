using RPG_Characters.Models.Classes;
using RPGCharacters.Models.Classes;
using Xunit;

namespace RPG_Characters_Tests
{
    public class RPGCharactersTests
    {
        [Fact]
        public void Constructor_InitializedSuccesfully_ShouldCreateLevel1Character()
        {

            // Arrange
            Warrior warrior = new Warrior();
            int expectedLevel = 1;

            // Act
            int actualLevel = warrior.Level;

            // Assert
            Assert.Equal(expectedLevel, actualLevel);
        }

        [Fact]
        public void GainLevel_GainedLevelSuccesfully_ShouldBeLevel2Character()
        {
            Warrior warrior = new Warrior();
            warrior.LevelUp();
            int expected = 2;

            int actual = warrior.Level;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_WarriorInitializedSuccesfullyWithDefaultValues_ShouldBeLevel1WarriorWithCorrectDefaultValues()
        {
            Warrior warrior = new Warrior();
            int expectedStrength = 5;
            int expectedDexterity = 2;
            int expextedIntelligence = 1;

            Assert.Equal(expectedStrength, warrior.Attributes.Strength);
            Assert.Equal(expectedDexterity, warrior.Attributes.Dexterity);
            Assert.Equal(expextedIntelligence, warrior.Attributes.Intelligence);
        }

        [Fact]
        public void GainLevel_WarriorGainedLevelSuccesfully_ShouldBeLevel2WarriorWithCorrectValuesAttributes()
        {
            Warrior warrior = new Warrior();
            warrior.LevelUp();

            int expectedStrength = 8;
            int expectedDexterity = 4;
            int expextedIntelligence = 2;

            Assert.Equal(expectedStrength, warrior.Attributes.Strength);
            Assert.Equal(expectedDexterity, warrior.Attributes.Dexterity);
            Assert.Equal(expextedIntelligence, warrior.Attributes.Intelligence);
        }

        [Fact]
        public void Constructor_MageInitializedSuccesfullyWithDefaultValues_ShouldBeLevel1MageWithCorrectDefaultValues()
        {
            Mage mage = new Mage();
            int expectedStrength = 1;
            int expectedDexterity = 1;
            int expextedIntelligence = 8;

            Assert.Equal(expectedStrength, mage.Attributes.Strength);
            Assert.Equal(expectedDexterity, mage.Attributes.Dexterity);
            Assert.Equal(expextedIntelligence, mage.Attributes.Intelligence);
        }

        [Fact]
        public void GainLevel_MageGainedLevelSuccesfully_ShouldBeLevel2MageWithCorrectValuesAttributes()
        {
            Mage mage = new Mage();
            mage.LevelUp();

            int expectedStrength = 2;
            int expectedDexterity = 2;
            int expextedIntelligence = 13;

            Assert.Equal(expectedStrength, mage.Attributes.Strength);
            Assert.Equal(expectedDexterity, mage.Attributes.Dexterity);
            Assert.Equal(expextedIntelligence, mage.Attributes.Intelligence);
        }
    }
}

using System;
using RPGCharacters.Models.Classes;
using Xunit;
using System.Collections.Generic;

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

            int actualStrength = warrior.BaseStrength.Value;
            int actualDexterity = warrior.BaseDexterity.Value;
            int actualIntelligence = warrior.BaseIntelligence.Value;

            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expextedIntelligence, actualIntelligence);
        }

        [Fact]
        public void GainLevel_WarriorGainedLevelSuccesfully_ShouldBeLevel2WarriorWithCorrectValuesAttributes()
        {
            Warrior warrior = new Warrior();
            warrior.LevelUp();

            int expectedStrength = 8;
            int expectedDexterity = 4;
            int expextedIntelligence = 2;

            int actualStrength = warrior.Strength.Value;
            int actualDexterity = warrior.Dexterity.Value;
            int actualIntelligence = warrior.Intelligence.Value;

            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expextedIntelligence, actualIntelligence);
        }
    }
}

using System;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Linq;
using RPGCharacters;

namespace RPG_Characters.Misc
{
    public class StatBuilder
    {
        public static string GenerateStats(string name, int level, float damage, PrimaryAttributes attributes)
        {
            StringBuilder stats = new StringBuilder();
            stats.AppendLine("Character statistics");
            stats.AppendLine($"Name: {name}");
            stats.AppendLine($"Level: {level}");

            // Base + gear bonus
            stats.AppendLine($"Strength: {attributes.Strength}");
            stats.AppendLine($"Dexterity: {attributes.Dexterity}");
            stats.AppendLine($"Intelligence: {attributes.Intelligence}");
            stats.AppendLine($"Damage: {damage}");

            return stats.ToString();
        }
    }
}

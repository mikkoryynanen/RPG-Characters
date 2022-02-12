namespace RPG_Characters.Models
{
    public abstract class Item
    {
        public enum Slot
        {
            Head,
            Body,
            Legs,
            Weapon
        }

        public string Name { get; private set; }
        public int RequiredLevel { get; private set; }
        public Slot ItemSlot { get; private set; }

        public Item(string name, int requiredlevel, Slot itemSlot)
        {
            Name = name;
            RequiredLevel = requiredlevel;
            ItemSlot = itemSlot;
        }
    }
}

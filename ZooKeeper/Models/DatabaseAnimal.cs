namespace ZooKeeper.Models
{
    public class DatabaseAnimal
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public int Type { get; set; }

        public int Color { get; set; }

        public string Name { get; set; }

        public DatabaseAnimal(string name, int type, int color, long userId)
        {
            Type = type;
            Color = color;
            Name = name;
            UserId = userId;
        }

        public DatabaseAnimal() { }
    }
}

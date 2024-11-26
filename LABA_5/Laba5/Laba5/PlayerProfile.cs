namespace Laba5
{
    public class PlayerProfile
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public PlayerProfile(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public override string ToString()
        {
            return $"Игрок: {Name}, Очки: {Score}";
        }
    }
}
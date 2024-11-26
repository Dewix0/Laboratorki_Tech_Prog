namespace Laba5
{
    public class PlayerProfileRepository : IPlayerProfileRepository
    {
        private readonly Dictionary<string, PlayerProfile> _profiles = new Dictionary<string, PlayerProfile>();

        // Обновление счета игрока
        public void UpdateScore(string playerName, int score)
        {
            if (_profiles.ContainsKey(playerName))
            {
                _profiles[playerName].Score = score;
            }
            else
            {
                _profiles[playerName] = new PlayerProfile(playerName, score);
            }
            Console.WriteLine($"Player {playerName} score updated to {score}");
        }

        // Получение профиля игрока
        public PlayerProfile GetProfile(string playerName)
        {
            _profiles.TryGetValue(playerName, out var profile);
            return profile;
        }
    }
}
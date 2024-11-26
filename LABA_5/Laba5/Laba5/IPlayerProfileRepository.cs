namespace Laba5
{
    public interface IPlayerProfileRepository
    {
        void UpdateScore(string playerName, int score);
        PlayerProfile GetProfile(string playerName);
    }
}
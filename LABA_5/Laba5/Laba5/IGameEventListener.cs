namespace Laba5
{
    public interface IGameEventListener
    {
        void OnGameEvent(GameEvent gameEvent, PlayerProfile playerProfile);
    }
}
using System;

namespace Laba5
{
    public class GameConsoleEventListener : IGameEventListener
    {
        public void OnGameEvent(GameEvent gameEvent, PlayerProfile playerProfile)
        {
            Console.WriteLine($"Событие: {gameEvent}, Игрок: {playerProfile.Name}, Очки: {playerProfile.Score}");
        }
    }
}
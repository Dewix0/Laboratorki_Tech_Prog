namespace Laba5
{
    public class GameUpdaterEventListener : IGameEventListener
    {
        private readonly IPlayerProfileRepository _repository;

        public GameUpdaterEventListener(IPlayerProfileRepository repository)
        {
            _repository = repository;
        }

        public void OnGameEvent(GameEvent gameEvent, PlayerProfile playerProfile)
        {
            _repository.UpdateScore(playerProfile.Name, playerProfile.Score);
        }
    }
}
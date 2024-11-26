using System.Collections.Generic;

namespace Laba5
{
    public class GameEventPublisher
    {
        private readonly Dictionary<GameEvent, List<IGameEventListener>> _listeners = new();

        public void Subscribe(GameEvent gameEvent, IGameEventListener listener)
        {
            if (!_listeners.ContainsKey(gameEvent))
                _listeners[gameEvent] = new List<IGameEventListener>();

            _listeners[gameEvent].Add(listener);
        }

        public void Unsubscribe(GameEvent gameEvent, IGameEventListener listener)
        {
            _listeners[gameEvent]?.Remove(listener);
        }

        public void NotifyAll(GameEvent gameEvent, PlayerProfile playerProfile)
        {
            if (_listeners.ContainsKey(gameEvent))
            {
                foreach (var listener in _listeners[gameEvent])
                {
                    listener.OnGameEvent(gameEvent, playerProfile);
                }
            }
        }
    }
}
namespace Laba5
{
    public abstract class DamageHandler
    {
        private DamageHandler _nextHandler;

        public DamageHandler SetNext(DamageHandler nextHandler)
        {
            _nextHandler = nextHandler;
            return _nextHandler;
        }

        public virtual int Handle(int damage)
        {
            return _nextHandler?.Handle(damage) ?? damage;
        }
    }
}
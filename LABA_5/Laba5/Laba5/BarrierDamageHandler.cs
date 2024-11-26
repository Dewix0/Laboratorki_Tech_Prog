namespace Laba5
{
    public class BarrierDamageHandler : DamageHandler
    {
        private readonly int _barrier;

        public BarrierDamageHandler(int barrier)
        {
            _barrier = barrier;
        }

        public override int Handle(int damage)
        {
            int damageAfterBarrier = damage - _barrier;
            return damageAfterBarrier > 0 ? base.Handle(damageAfterBarrier) : 0;
        }
    }
}
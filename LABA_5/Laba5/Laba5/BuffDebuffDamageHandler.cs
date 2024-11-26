namespace Laba5
{
    public class BuffDebuffDamageHandler : DamageHandler
    {
        private readonly float _damageModifier;

        public BuffDebuffDamageHandler(float damageModifier)
        {
            _damageModifier = damageModifier;
        }

        public override int Handle(int damage)
        {
            int modifiedDamage = (int)(damage * _damageModifier);
            return base.Handle(modifiedDamage);
        }
    }
}
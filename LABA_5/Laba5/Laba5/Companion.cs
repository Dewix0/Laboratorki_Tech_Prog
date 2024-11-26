namespace Laba5
{
    public class Companion
    {
        private ICompanionAttackStrategy _attackStrategy;

        public Companion(CharacterClass characterClass)
        {
            _attackStrategy = characterClass switch
            {
                CharacterClass.Warrior => new AggressiveAttackStrategy(),
                CharacterClass.Thief => new DefensiveAttackStrategy(),
                _ => new DefensiveAttackStrategy()
            };
        }

        public void Attack(Enemy enemy)
        {
            _attackStrategy.Attack(enemy);
        }
    }
}
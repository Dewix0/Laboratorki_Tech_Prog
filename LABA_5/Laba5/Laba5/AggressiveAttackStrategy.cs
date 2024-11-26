using System;

namespace Laba5
{
    public class AggressiveAttackStrategy : ICompanionAttackStrategy
    {
        public void Attack(Enemy enemy)
        {
            int damage = 30;
            enemy.TakeDamage(damage);
            Console.WriteLine($"Агрессивная атака: Нанесено {damage} урона");
        }
    }
}
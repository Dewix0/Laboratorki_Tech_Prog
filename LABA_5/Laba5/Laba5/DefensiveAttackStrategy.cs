using System;

namespace Laba5
{
    public class DefensiveAttackStrategy : ICompanionAttackStrategy
    {
        public void Attack(Enemy enemy)
        {
            int damage = 10;
            enemy.TakeDamage(damage);
            Console.WriteLine($"Оборонительная атака: Нанесено {damage} урона");
        }
    }
}
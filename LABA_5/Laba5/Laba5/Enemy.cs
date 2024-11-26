using System;

namespace Laba5
{
    public class Enemy
    {
        public int Health { get; private set; }

        public Enemy(int health)
        {
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"Враг получил {damage} урона, текущее здоровье врага: {Health}");
        }
    }
}
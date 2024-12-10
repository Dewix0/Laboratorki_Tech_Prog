using System;

namespace Laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            // ==== Chain of Responsibility Example ====
            Console.WriteLine("=== Chain of Responsibility ===");
            
            int initialDamage = 50;

            // Создание цепочки обработчиков урона
            DamageHandler handler = new BarrierDamageHandler(10);
            handler.SetNext(new BuffDebuffDamageHandler(1.2f))
                   .SetNext(new InvulnerabilityDamageHandler());

            // Применение цепочки для обработки урона
            int finalDamage = handler.Handle(initialDamage);
            Console.WriteLine($"Начальный урон: {initialDamage}, Финальный урон после обработки: {finalDamage}");

            // ==== Strategy Example ====
            Console.WriteLine("\n=== Strategy Pattern ====");

            // Создаём врага и компаньонов с разными стратегиями атаки
            Enemy enemy = new Enemy(health: 100);

            Companion warriorCompanion = new Companion(CharacterClass.Warrior);
            Companion thiefCompanion = new Companion(CharacterClass.Thief);

            Console.WriteLine("Атака воина:");
            warriorCompanion.Attack(enemy);

            Console.WriteLine("Атака вора:");
            thiefCompanion.Attack(enemy);

            // ==== Observer Example ====
            Console.WriteLine("\n=== Observer Pattern ====");

            // Создание профиля игрока
            PlayerProfile playerProfile = new PlayerProfile("Player1", 0);

            // Создание репозитория для профилей
            IPlayerProfileRepository playerProfileRepository = new PlayerProfileRepository();

            // Создание издателя событий и добавление слушателей
            var eventPublisher = new GameEventPublisher();
            var consoleListener = new GameConsoleEventListener();

            // Передаем репозиторий в GameUpdaterEventListener
            var updaterListener = new GameUpdaterEventListener(playerProfileRepository); // Параметр теперь правильный

            // Подписка на события
            eventPublisher.Subscribe(GameEvent.LevelUp, consoleListener);
            eventPublisher.Subscribe(GameEvent.LevelUp, updaterListener);

            // Уведомление о событии уровня вверх
            playerProfile.Score = 100; // например, игрок набрал 100 очков
            eventPublisher.NotifyAll(GameEvent.LevelUp, playerProfile);

            // Проверка обновления профиля
            Console.WriteLine($"Профиль после события: Имя: {playerProfile.Name}, Очки: {playerProfile.Score}");

            // Уведомление о событии окончания игры
            eventPublisher.Subscribe(GameEvent.GameOver, consoleListener);
            eventPublisher.NotifyAll(GameEvent.GameOver, playerProfile);

            Console.WriteLine("=== Конец работы ===");
        }
    }
}   
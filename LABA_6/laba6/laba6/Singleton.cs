namespace laba6;

public class Singleton
{
    private static Singleton _instance;

    // Приватный конструктор, чтобы предотвратить создание объектов
    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

    public string GetMessage()
    {
        return "Singleton instance";
    }
}
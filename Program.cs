using OOPLab4.Events;

namespace OOPLab4;

internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\nЛабораторна робота 3.4 — варіант 4");
            Console.WriteLine("1. Сортування символів за спаданням через делегат");
            Console.WriteLine("2. Перевірити обмежену чергу та подію переповнення");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CharacterSortDemo.Run();
                    break;
                case "2":
                    QueueDemo.Run();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невідомий пункт меню.");
                    break;
            }
        }
    }
}
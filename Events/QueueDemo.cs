namespace OOPLab4.Events;

internal static class QueueDemo
{
    public static void Run()
    {
        int capacity = ReadPositiveInteger("Введіть місткість черги: ");
        var queue = new BoundedCharQueue(capacity);
        var handler = new QueueEventHandler();

        // Підписуємо окремий метод-обробник на подію.
        queue.Overflowed += handler.OnQueueOverflow;

        while (true)
        {
            Console.WriteLine($"\nЧерга: [{queue.GetContents()}] ({queue.Count}/{queue.Capacity})");
            Console.WriteLine("1. Додати символ");
            Console.WriteLine("2. Видалити перший символ");
            Console.WriteLine("3. Очистити чергу");
            Console.WriteLine("0. Повернутися до головного меню");
            Console.Write("Ваш вибір: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Символ для додавання: ");
                    string? text = Console.ReadLine();
                    if (string.IsNullOrEmpty(text))
                    {
                        Console.WriteLine("Потрібно ввести хоча б один символ.");
                        break;
                    }

                    if (queue.TryEnqueue(text[0]))
                    {
                        Console.WriteLine($"Символ '{text[0]}' додано.");
                    }
                    else
                    {
                        Console.WriteLine("Додавання не виконано.");
                    }
                    break;
                case "2":
                    if (queue.TryDequeue(out char removed))
                    {
                        Console.WriteLine($"Видалено символ '{removed}'.");
                    }
                    else
                    {
                        Console.WriteLine("Черга порожня.");
                    }
                    break;
                case "3":
                    queue.Clear();
                    Console.WriteLine("Чергу очищено.");
                    break;
                case "0":
                    queue.Overflowed -= handler.OnQueueOverflow;
                    return;
                default:
                    Console.WriteLine("Невідомий пункт меню.");
                    break;
            }
        }
    }

    private static int ReadPositiveInteger(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Введіть ціле число, більше за нуль.");
        }
    }
}
namespace OOPLab4.Events;

// Окремий клас містить обробник події зі стандартною сигнатурою .NET.
internal sealed class QueueEventHandler
{
    public void OnQueueOverflow(object? sender, QueueOverflowEventArgs eventArgs)
    {
        string sourceName = sender is BoundedCharQueue ? "черга" : "невідоме джерело";
        Console.WriteLine(
            $"Подія переповнення ({sourceName}): місткість {eventArgs.Capacity}, " +
            $"елементів {eventArgs.CurrentCount}, відхилено символ '{eventArgs.AttemptedValue}'.");
    }
}
namespace OOPLab4.Events;

// Черга з фіксованою місткістю. Вона повідомляє підписників про кожну невдалу спробу додавання.
internal class BoundedCharQueue
{
    private readonly Queue<char> _items = new();

    public int Capacity { get; }
    public int Count => _items.Count;
    public bool IsEmpty => _items.Count == 0;
    public bool IsFull => _items.Count == Capacity;

    public event EventHandler<QueueOverflowEventArgs>? Overflowed;

    public BoundedCharQueue(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Місткість має бути більшою за нуль.");
        }

        Capacity = capacity;
    }

    public bool TryEnqueue(char value)
    {
        if (IsFull)
        {
            OnOverflowed(new QueueOverflowEventArgs(Capacity, Count, value));
            return false;
        }

        _items.Enqueue(value);
        return true;
    }

    public bool TryDequeue(out char value)
    {
        return _items.TryDequeue(out value);
    }

    public void Clear()
    {
        _items.Clear();
    }

    public string GetContents()
    {
        return new string(_items.ToArray());
    }

    // Метод викликає подію. Захищений рівень доступу дозволяє перевизначення в похідному класі.
    protected virtual void OnOverflowed(QueueOverflowEventArgs eventArgs)
    {
        Overflowed?.Invoke(this, eventArgs);
    }
}
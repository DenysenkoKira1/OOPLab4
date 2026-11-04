namespace OOPLab4.Events;

// Аргументи містять дані про спробу додати елемент до заповненої черги.
internal sealed class QueueOverflowEventArgs : EventArgs
{
    public int Capacity { get; }
    public int CurrentCount { get; }
    public char AttemptedValue { get; }

    public QueueOverflowEventArgs(int capacity, int currentCount, char attemptedValue)
    {
        Capacity = capacity;
        CurrentCount = currentCount;
        AttemptedValue = attemptedValue;
    }
}
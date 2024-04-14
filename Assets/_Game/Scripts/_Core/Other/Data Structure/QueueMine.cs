using System.Collections.Generic;

public class QueueMine<T>
{
    public readonly Queue<T> queue;

    public QueueMine()
    {
        queue = new Queue<T>();
    }
    public QueueMine(IEnumerable<T> collection)
    {
        queue = new Queue<T>(collection);
    }

    public event System.Action<int> onChanged;
    public event System.Action<T> onEnqueue;
    public event System.Action<T> onDequeue;

    public int Count { get { return queue.Count; } }

    public virtual void Enqueue(T item)
    {
        queue.Enqueue(item);
        onEnqueue?.Invoke(item);
        onChanged?.Invoke(Count);
    }

    public virtual T Dequeue()
    {
        T item = queue.Dequeue();
        onDequeue?.Invoke(item);
        onChanged?.Invoke(Count);
        return item;
    }
}
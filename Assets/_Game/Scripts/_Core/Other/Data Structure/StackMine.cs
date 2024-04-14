using System.Collections.Generic;

public class StackMine<T>
{
    public readonly Stack<T> stack;

    public StackMine()
    {
        stack = new Stack<T>();
    }
    public StackMine(IEnumerable<T> collection)
    {
        stack = new Stack<T>(collection);
    }

    public event System.Action<int> onChanged;
    public event System.Action<T> onAdd;
    public event System.Action<T> onRemove;

    public int Count { get { return stack.Count; } }

    public void Add(T item)
    {
        stack.Push(item);
        onAdd?.Invoke(item);
        onChanged?.Invoke(Count);
    }

    public T Remove()
    {
        T item = stack.Pop();
        onRemove?.Invoke(item);
        onChanged?.Invoke(Count);
        return item;
    }
}
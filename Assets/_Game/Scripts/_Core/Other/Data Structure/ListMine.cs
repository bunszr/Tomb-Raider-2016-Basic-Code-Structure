using System.Collections.Generic;

public class ListMine<T>
{
    public readonly List<T> list;

    public ListMine()
    {
        list = new List<T>();
    }
    public ListMine(IEnumerable<T> collection)
    {
        list = new List<T>(collection);
    }

    public event System.Action<int> onChanged;
    public event System.Action<T> onAdd;
    public event System.Action<T> onRemove;

    public int Count { get { return list.Count; } }

    public void Add(T item)
    {
        list.Add(item);
        onAdd?.Invoke(item);
        onChanged?.Invoke(Count);
    }

    public T Remove(T item)
    {
        list.Remove(item);
        onRemove?.Invoke(item);
        onChanged?.Invoke(Count);
        return item;
    }
}
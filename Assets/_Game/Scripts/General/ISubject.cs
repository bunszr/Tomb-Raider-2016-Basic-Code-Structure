public interface ISubject<T> where T : IObserver
{
    void Register(T observer);
    void Unregister(T observer);
}
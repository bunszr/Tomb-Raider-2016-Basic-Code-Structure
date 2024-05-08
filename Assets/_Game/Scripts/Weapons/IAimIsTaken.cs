using UniRx;

public interface IAimIsTaken
{
    ReactiveProperty<bool> HasAimed { get; }
}
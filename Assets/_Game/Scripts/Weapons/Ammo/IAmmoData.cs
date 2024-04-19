using UniRx;

public interface IAmmoData
{
    ReactiveProperty<int> BulletCountInMagazineRP { get; }
    ReactiveProperty<int> CurrAmmoCapacityRP { get; }
    ReactiveProperty<int> MagazineCapacityRP { get; }
}
using UniRx;

public interface IAmmoData
{
    ReactiveProperty<int> CurrAmmoRP { get; set; }
    ReactiveProperty<int> TotalAmmoRP { get; set; }
    ReactiveProperty<int> MagazineCapacity { get; set; }
}
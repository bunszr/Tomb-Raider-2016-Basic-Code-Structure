using UniRx;

public class FireAmmo : IAmmoData
{
    public ReactiveProperty<int> CurrAmmoRP { get; set; }
    public ReactiveProperty<int> TotalAmmoRP { get; set; }
    public ReactiveProperty<int> MagazineCapacity { get; set; }

    public FireAmmo()
    {
        CurrAmmoRP = new ReactiveProperty<int>(3);
        TotalAmmoRP = new ReactiveProperty<int>(7);
        MagazineCapacity = new ReactiveProperty<int>(3);
    }
}
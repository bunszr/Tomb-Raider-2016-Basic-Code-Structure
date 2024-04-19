using UniRx;

public class FireAmmo : IAmmoData
{
    public ReactiveProperty<int> BulletCountInMagazineRP { get; set; }
    public ReactiveProperty<int> CurrAmmoCapacityRP { get; set; }
    public ReactiveProperty<int> MagazineCapacityRP { get; set; }

    public FireAmmo(FireAmmoSaveable fireAmmoSaveable)
    {
        BulletCountInMagazineRP = new ReactiveProperty<int>(fireAmmoSaveable.magazineCapacity);
        MagazineCapacityRP = new ReactiveProperty<int>(fireAmmoSaveable.magazineCapacity);
        CurrAmmoCapacityRP = new ReactiveProperty<int>(fireAmmoSaveable.currAmmoCapacity);
    }
}
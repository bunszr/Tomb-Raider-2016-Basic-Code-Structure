using Sirenix.OdinInspector;
using UniRx;

public class FireAmmo : IAmmoData
{
    [ReadOnly, ShowInInspector] public ReactiveProperty<int> BulletCountInMagazineRP { get; set; }
    [ReadOnly, ShowInInspector] public ReactiveProperty<int> CurrAmmoCapacityRP { get; set; }
    [ReadOnly, ShowInInspector] public ReactiveProperty<int> MagazineCapacityRP { get; set; }

    public FireAmmo(FireAmmoSaveable fireAmmoSaveable)
    {
        BulletCountInMagazineRP = new ReactiveProperty<int>(fireAmmoSaveable.magazineCapacity);
        MagazineCapacityRP = new ReactiveProperty<int>(fireAmmoSaveable.magazineCapacity);
        CurrAmmoCapacityRP = new ReactiveProperty<int>(fireAmmoSaveable.currAmmoCapacity);
    }
}
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

public class NormalAmmo : IAmmoData
{
    [ReadOnly, ShowInInspector] public ReactiveProperty<int> BulletCountInMagazineRP { get; private set; }
    [ReadOnly, ShowInInspector] public ReactiveProperty<int> MagazineCapacityRP { get; private set; }
    [ReadOnly, ShowInInspector] public ReactiveProperty<int> CurrAmmoCapacityRP { get; private set; }

    public NormalAmmo(NormalAmmoSaveable normalAmmoSaveable)
    {
        BulletCountInMagazineRP = new ReactiveProperty<int>(normalAmmoSaveable.magazineCapacity);
        MagazineCapacityRP = new ReactiveProperty<int>(normalAmmoSaveable.magazineCapacity);
        CurrAmmoCapacityRP = new ReactiveProperty<int>(normalAmmoSaveable.currAmmoCapacity);
    }
}
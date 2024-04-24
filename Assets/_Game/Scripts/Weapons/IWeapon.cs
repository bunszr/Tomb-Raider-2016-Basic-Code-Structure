using UniRx;
using UnityEngine;

public interface IWeapon
{
    Transform Transform { get; }
    void Equip();
    void Unequip();
    void Fire();
    ReactiveProperty<IAmmoData> _AmmoRP { get; set; }
}
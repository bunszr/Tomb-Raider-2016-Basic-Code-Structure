using UniRx;
using UnityEngine;

public interface IWeapon
{
    Transform Transform { get; }
    ReactiveProperty<bool> HasEquipRP { get; }
    void Equip();
    void Unequip();
}
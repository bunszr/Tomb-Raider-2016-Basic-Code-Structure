using BehaviorDesigner.Runtime.Tasks;
using UniRx;
using UnityEngine;

public interface IWeapon
{
    Transform Transform { get; }
    WeaponTypeScriptable WeaponTypeScriptable { get; }
    void Equip();
    void Unequip();
    void Fire();
    IAmmoData GetAmmoData();
    WeaponData WeaponData { get; set; }
}
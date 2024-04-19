using UnityEngine;

public interface IWeapon
{
    Transform Transform { get; }
    void Equip();
    void Unequip();
    void Fire();
    IAmmoData GetAmmoData();
}
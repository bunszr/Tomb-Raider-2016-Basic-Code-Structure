using UnityEngine;

[System.Serializable]
public class NormalAmmoSaveable
{
    public int magazineCapacity = 4;
    public int currAmmoCapacity = 10;

    public NormalAmmoSaveable(int magazineCapacity, int currAmmoCapacity)
    {
        this.magazineCapacity = magazineCapacity;
        this.currAmmoCapacity = currAmmoCapacity;
    }

    public static implicit operator NormalAmmoSaveable(NormalAmmo normalAmmo)
    {
        return new NormalAmmoSaveable(normalAmmo.MagazineCapacityRP.Value, normalAmmo.CurrAmmoCapacityRP.Value);
    }
}
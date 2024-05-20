[System.Serializable]
public class FireAmmoSaveable
{
    public int magazineCapacity;
    public int currAmmoCapacity;

    public FireAmmoSaveable(int magazineCapacity, int currAmmoCapacity)
    {
        this.magazineCapacity = magazineCapacity;
        this.currAmmoCapacity = currAmmoCapacity;
    }

    public static implicit operator FireAmmoSaveable(FireAmmo fireAmmo)
    {
        return new FireAmmoSaveable(fireAmmo.MagazineCapacityRP.Value, fireAmmo.CurrAmmoCapacityRP.Value);
    }
}
using UnityEngine;

public class FillMagazineState : WeaponStateBase
{
    public FillMagazineState(WeaponBase weaponBase, bool needsExitTime, bool isGhostState = false) : base(weaponBase, needsExitTime, isGhostState) { }

    public override void OnEnter()
    {
        int emptySlotCountInMagazine = weaponBase._AmmoDataRP.Value.MagazineCapacityRP.Value - weaponBase._AmmoDataRP.Value.BulletCountInMagazineRP.Value;
        int bulletCountToGivenMagazine = Mathf.Min(emptySlotCountInMagazine, weaponBase._AmmoDataRP.Value.CurrAmmoCapacityRP.Value);
        weaponBase._AmmoDataRP.Value.BulletCountInMagazineRP.Value += bulletCountToGivenMagazine;
        weaponBase._AmmoDataRP.Value.CurrAmmoCapacityRP.Value -= Mathf.Min(emptySlotCountInMagazine, bulletCountToGivenMagazine);
    }
}
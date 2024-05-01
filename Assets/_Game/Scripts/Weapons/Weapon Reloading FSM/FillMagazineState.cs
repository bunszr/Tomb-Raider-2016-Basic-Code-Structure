using UnityEngine;

public class FillMagazineState : WeaponStateBase
{
    public FillMagazineState(WeaponBase weaponBase, bool needsExitTime, bool isGhostState = false) : base(weaponBase, needsExitTime, isGhostState) { }

    public override void OnEnter()
    {
        int emptySlotCountInMagazine = weaponBase._AmmoRP.Value.MagazineCapacityRP.Value - weaponBase._AmmoRP.Value.BulletCountInMagazineRP.Value;
        int bulletCountToGivenMagazine = Mathf.Min(emptySlotCountInMagazine, weaponBase._AmmoRP.Value.CurrAmmoCapacityRP.Value);
        weaponBase._AmmoRP.Value.BulletCountInMagazineRP.Value += bulletCountToGivenMagazine;
        weaponBase._AmmoRP.Value.CurrAmmoCapacityRP.Value -= Mathf.Min(emptySlotCountInMagazine, bulletCountToGivenMagazine);
    }
}
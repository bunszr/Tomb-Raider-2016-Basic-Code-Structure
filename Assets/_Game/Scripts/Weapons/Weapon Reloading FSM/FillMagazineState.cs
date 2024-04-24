using UnityEngine;

public class FillMagazineState : WeaponStateBase
{
    public FillMagazineState(IWeapon _weapon, bool needsExitTime, bool isGhostState = false) : base(_weapon, needsExitTime, isGhostState) { }

    public override void OnEnter()
    {
        int emptySlotCountInMagazine = _weapon._AmmoRP.Value.MagazineCapacityRP.Value - _weapon._AmmoRP.Value.BulletCountInMagazineRP.Value;
        int bulletCountToGivenMagazine = Mathf.Min(emptySlotCountInMagazine, _weapon._AmmoRP.Value.CurrAmmoCapacityRP.Value);
        _weapon._AmmoRP.Value.BulletCountInMagazineRP.Value += bulletCountToGivenMagazine;
        _weapon._AmmoRP.Value.CurrAmmoCapacityRP.Value -= Mathf.Min(emptySlotCountInMagazine, bulletCountToGivenMagazine);
    }
}
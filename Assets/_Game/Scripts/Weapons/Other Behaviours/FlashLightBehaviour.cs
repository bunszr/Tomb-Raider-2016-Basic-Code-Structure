using UnityEngine;

public class FlashLightBehaviour : IEquiptable
{
    WeaponBase weaponBase;
    IFlashLightAddOn _flashLightAddOn;

    public FlashLightBehaviour(WeaponBase weaponBase)
    {
        this.weaponBase = weaponBase;
        _flashLightAddOn = weaponBase as IFlashLightAddOn;
        _flashLightAddOn.FlashLightAddOnData.addOn.SetActive(true);
    }

    public virtual void Enter() => UpdateManager.Ins.RegisterAsUpdate(weaponBase, OnUpdate);
    public virtual void Exit() => UpdateManager.Ins.UnregisterAsUpdate(weaponBase, OnUpdate);

    void OnUpdate()
    {
        if (IM.Ins.Input.WeaponInput.HasPressFlashLightKey) _flashLightAddOn.FlashLightAddOnData.light.enabled = !_flashLightAddOn.FlashLightAddOnData.light.enabled;
    }
}
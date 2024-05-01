using UnityEngine;

public class FlashLightBehaviour : IFlashBehaviour, IEquiptable
{
    WeaponBase weaponBase;
    FlashLightAddOnData flashLightAddOnData;

    public FlashLightBehaviour(WeaponBase weapon, FlashLightAddOnData flashLightAddOnData)
    {
        weaponBase = weapon;
        this.flashLightAddOnData = flashLightAddOnData;
    }

    public virtual void Enter() => UpdateManager.Ins.RegisterAsUpdate(weaponBase, OnUpdate);
    public virtual void Exit() => UpdateManager.Ins.UnregisterAsUpdate(weaponBase, OnUpdate);

    void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q)) flashLightAddOnData.light.enabled = !flashLightAddOnData.light.enabled;
    }
}
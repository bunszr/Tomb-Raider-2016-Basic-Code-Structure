using UnityEngine;

public class FlashLightBehaviour : IFlashBehaviour
{
    IWeapon _weapon;
    FlashLightAddOnData flashLightAddOnData;

    public FlashLightBehaviour(IWeapon weapon, FlashLightAddOnData flashLightAddOnData)
    {
        _weapon = weapon;
        this.flashLightAddOnData = flashLightAddOnData;
    }

    public void Enter()
    {
        MonoEvents monoEvents = _weapon.Transform.GetComponent<MonoEvents>();
        monoEvents.onUpdate += OnUpdate;
    }

    public void Exit()
    {
        MonoEvents monoEvents = _weapon.Transform.GetComponent<MonoEvents>();
        monoEvents.onUpdate -= OnUpdate;
    }

    void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q)) flashLightAddOnData.light.enabled = !flashLightAddOnData.light.enabled;
    }
}
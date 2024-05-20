using Sirenix.OdinInspector;
using UnityEngine;

public class AK47 : PlayerWeaponBase, ISuppressorAddOn, IFlashLightAddOn
{
    public SuppressorFeatureScriptable suppressorFeatureScriptable;
    public FlashLightFeatureScriptable flashLightFeatureScriptable;

    public NormalBulletBehaviour.NormalBulletBehaviourData normalBulletModeData;
    public NormalShellCasingBehaviour.NormalShellCasingBehaviourData normalShellCasingData;
    public NormalMuzzleBehaviour.NormalMuzzleBehaviourData normalMuzzleBehaviourData;
    public FlashLightAddOnData flashLightAddOnData;
    public GameObject suppressorGO;

    public GameObject SuppressorGO => suppressorGO;
    public FlashLightAddOnData FlashLightAddOnData => flashLightAddOnData;
}

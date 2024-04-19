using UniRx;
using UnityEngine;
using Zenject;

public class SMG01lInstaller : MonoBehaviour
{
    private void Awake()
    {
        SMG01 sMG01 = transform.parent.GetComponentInChildren<SMG01>();

        sMG01._bulletBehaviour = new NormalBulletBehaviour(sMG01, sMG01.normalBulletModeData);
        sMG01._fireMode = new AutomaticFireBehavior(sMG01, sMG01.automaticFireBehaviorData);
        sMG01._shellCasingBehaviour = new NormalShellCasingBehaviour(sMG01, sMG01.normalShellCasingData);
        sMG01._recoilBehaviour = new PistolRecoilBehaviour(sMG01, sMG01.pistolRecoilBehaviourData);

        sMG01.Equip();
    }
}
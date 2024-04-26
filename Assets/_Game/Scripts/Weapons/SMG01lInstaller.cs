using UniRx;
using UnityEngine;
using Zenject;

public class SMG01lInstaller : WeaponBaseInstaller
{
    protected override void Awake()
    {
        base.Awake();
        SMG01 sMG01 = weaponBase as SMG01;

        // sMG01._bulletBehaviour = new NormalBulletBehaviour(sMG01, sMG01.normalBulletModeData);
        sMG01._bulletBehaviour = new SplineBulletBehaviour(sMG01, sMG01.splineBulletBehaviourData);
        sMG01._fireMode = new AutomaticFireBehavior(sMG01, _input.WeaponInput);
        sMG01._shellCasingBehaviour = new NormalShellCasingBehaviour(sMG01, sMG01.normalShellCasingData);
        sMG01._recoilBehaviour = new PistolRecoilBehaviour(sMG01, sMG01.pistolRecoilBehaviourData);
    }
}
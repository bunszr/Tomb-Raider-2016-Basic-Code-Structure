using UniRx;
using UnityEngine;
using Zenject;

public class PistolInstaller : WeaponBaseInstaller
{
    Pistol pistol;

    protected override void Awake()
    {
        base.Awake();
        pistol = weaponBase as Pistol;

        pistol._bulletBehaviour = new NormalBulletBehaviour(pistol, pistol.normalBulletModeData);
        pistol._fireMode = new SingleShotBehavior(pistol, _input.WeaponInput);
        pistol._shellCasingBehaviour = new NormalShellCasingBehaviour(pistol, pistol.normalShellCasingData);
        pistol._recoilBehaviour = new PistolRecoilBehaviour(pistol, pistol.pistolRecoilBehaviourData);
    }

    protected override void Start()
    {
        base.Start();
        pistol.Equip();
    }
}
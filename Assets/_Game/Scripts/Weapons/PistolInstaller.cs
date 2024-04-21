using UniRx;
using UnityEngine;
using Zenject;

public class PistolInstaller : BaseWeaponInstaller
{
    Pistol pistol;

    protected override void Awake()
    {
        base.Awake();
        pistol = weaponBase as Pistol;

        pistol._bulletBehaviour = new NormalBulletBehaviour(pistol, pistol.normalBulletModeData);
        pistol._fireMode = new SingleShot(pistol, pistol.singleShotData);
        pistol._shellCasingBehaviour = new NormalShellCasingBehaviour(pistol, pistol.normalShellCasingData);
        pistol._recoilBehaviour = new PistolRecoilBehaviour(pistol, pistol.pistolRecoilBehaviourData);
    }

    protected override void Start()
    {
        base.Start();
        pistol.Equip();
    }
}
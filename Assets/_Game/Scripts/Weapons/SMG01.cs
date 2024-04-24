using Sirenix.OdinInspector;
using UnityEngine;

public class SMG01 : WeaponBase
{
    public NormalBulletBehaviour.NormalBulletBehaviourData normalBulletModeData;
    public NormalShellCasingBehaviour.NormalShellCasingBehaviourData normalShellCasingData;
    public PistolRecoilBehaviour.PistolRecoilBehaviourData pistolRecoilBehaviourData;

    [ShowInInspector] public IBulletBehaviour _bulletBehaviour;
    [ShowInInspector] public IShellCasingBehaviour _shellCasingBehaviour;
    [ShowInInspector] public IRecoilBehaviour _recoilBehaviour;

    public override void Fire()
    {
        _bulletBehaviour.Fire();
        _shellCasingBehaviour.Execute();
        _recoilBehaviour.Execute();
    }
}
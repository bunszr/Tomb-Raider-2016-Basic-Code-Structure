using BehaviorDesigner.Runtime.Tasks;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

public class Pistol : WeaponBase
{
    public NormalAmmo normalAmmo;

    public SingleShot.SingleShotData singleShotData;
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

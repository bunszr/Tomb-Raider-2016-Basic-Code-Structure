using BehaviorDesigner.Runtime.Tasks;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

public class Shotgun : WeaponBase
{
    public NormalAmmo normalAmmo;

    public SingleShot.SingleShotData singleShotData;
    public ScatterBulletBehaviour.ScatterBulletBehaviourData scatterBulletBehaviourData;

    [ShowInInspector] public IBulletBehaviour _bulletBehaviour;

    public override void Fire()
    {
        _bulletBehaviour.Fire();
    }
}

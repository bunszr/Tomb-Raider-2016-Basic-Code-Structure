using Sirenix.OdinInspector;

public class Shotgun : WeaponBase
{
    public NormalAmmo normalAmmo;

    public ScatterBulletBehaviour.ScatterBulletBehaviourData scatterBulletBehaviourData;

    [ShowInInspector] public IBulletBehaviour _bulletBehaviour;

    public override void Fire()
    {
        _bulletBehaviour.Fire();
    }
}

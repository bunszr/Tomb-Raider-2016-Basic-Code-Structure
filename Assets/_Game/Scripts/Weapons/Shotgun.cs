using Sirenix.OdinInspector;

public class Shotgun : PlayerWeaponBase
{
    public NormalAmmo normalAmmo;

    public ScatterBulletBehaviour.ScatterBulletBehaviourData scatterBulletBehaviourData;

    [ShowInInspector] public IBulletBehaviour _bulletBehaviour;
}

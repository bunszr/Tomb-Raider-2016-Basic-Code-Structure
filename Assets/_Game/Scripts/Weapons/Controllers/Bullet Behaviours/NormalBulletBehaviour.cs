using Lean.Pool;
using UnityEngine;

public class NormalBulletBehaviour : BulletBehaviourBase, IBulletBehaviour, IExtraFire
{
    [System.Serializable]
    public class NormalBulletBehaviourData
    {
        public BulletBase bulletPrefab;
        public Transform bulletLocation;
        public ForceMode forceMode = ForceMode.VelocityChange;
        public float force = 20;
    }

    public NormalBulletBehaviourData data;

    public NormalBulletBehaviour(WeaponBase weaponBase, NormalBulletBehaviourData data) : base(weaponBase)
    {
        this.data = data;
    }

    public void Fire()
    {
        BulletBase bulletBase = LeanPool.Spawn(data.bulletPrefab, data.bulletLocation.position, data.bulletLocation.rotation, BulletHolder);
        bulletBase.Rb.AddForce(data.bulletLocation.forward * data.force, data.forceMode);
        LeanPool.Despawn(bulletBase, 5);
    }
}

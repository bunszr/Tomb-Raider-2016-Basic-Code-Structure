using Lean.Pool;
using UnityEngine;

public class ScatterBulletBehaviour : BulletBehaviourBase
{
    [System.Serializable]
    public class ScatterBulletBehaviourData
    {
        public BulletBase bulletPrefab;
        public float rotation = 20;
        public int scatterCount = 3;
        public Transform bulletLocation;
        public ForceMode forceMode = ForceMode.VelocityChange;
        public float force = 20;
    }

    public ScatterBulletBehaviourData data;

    public ScatterBulletBehaviour(WeaponBase weaponBase, ScatterBulletBehaviourData data) : base(weaponBase)
    {
        this.data = data;
    }

    public override void Fire()
    {
        base.Fire();
        for (int i = 0; i < data.scatterCount; i++)
        {
            Quaternion rndRot = data.bulletLocation.rotation * Quaternion.Euler(Random.Range(-data.rotation, data.rotation), Random.Range(-data.rotation, data.rotation), Random.Range(-data.rotation, data.rotation));
            BulletBase bulletBase = LeanPool.Spawn(data.bulletPrefab, data.bulletLocation.position, rndRot, BulletHolder);
            bulletBase.Rb.AddForce(bulletBase.transform.forward * data.force, data.forceMode);
            LeanPool.Despawn(bulletBase, 5);
        }
    }
}

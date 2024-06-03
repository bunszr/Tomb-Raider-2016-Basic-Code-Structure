using DG.Tweening;
using Lean.Pool;
using UnityEngine;

public class SplineBulletBehaviour : BulletBehaviourBase
{
    [System.Serializable]
    public class SplineBulletBehaviourData
    {
        public BulletBase bulletPrefab;
        public Transform bulletLocation;
        public Ease ease = Ease.OutQuad;
    }

    public SplineBulletBehaviourData data;
    WeaponAimData weaponAimData;

    public SplineBulletBehaviour(WeaponBase weaponBase, SplineBulletBehaviourData data, WeaponAimData weaponAimData) : base(weaponBase)
    {
        this.data = data;
        this.weaponAimData = weaponAimData;
    }

    public override void Fire()
    {
        base.Fire();
        BulletBase bulletBase = LeanPool.Spawn(data.bulletPrefab, data.bulletLocation.position, data.bulletLocation.rotation, BulletHolder);

        Vector3 startPos = data.bulletLocation.transform.position;
        Vector3 targetPos = weaponAimData.aimTargetTransform.position;
        Vector3[] path = new Vector3[]
        {
            data.bulletLocation.transform.position,
            startPos + (targetPos - startPos) * .2f,
            startPos + (targetPos - startPos) * .5f + Quaternion.AngleAxis(Random.value * 360, targetPos - startPos) * Vector3.right,
            startPos + (targetPos - startPos) * .8f + Quaternion.AngleAxis(Random.value * 360, targetPos - startPos) * Vector3.right,
            targetPos,
        };

        bulletBase.transform.DOPath(path, 2, PathType.CatmullRom, gizmoColor: Color.red).SetLookAt(0.1f).SetEase(Ease.OutSine).SetUpdate(UpdateType.Fixed)
        .OnComplete(() =>
        {
            LeanPool.Despawn(bulletBase);
        });
    }
}

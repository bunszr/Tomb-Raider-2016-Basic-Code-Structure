using DG.Tweening;
using Lean.Pool;
using UnityEngine;

public class SplineBulletBehaviour : BulletBehaviourBase, IBulletBehaviour
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

    public SplineBulletBehaviour(IWeapon _weapon, SplineBulletBehaviourData data) : base(_weapon)
    {
        weaponAimData = _weapon.Transform.GetComponentInParent<WeaponAimData>();
        this.data = data;
    }

    public void Fire()
    {
        BulletBase bulletBase = LeanPool.Spawn(data.bulletPrefab, data.bulletLocation.position, data.bulletLocation.rotation);
        LeanPool.Despawn(bulletBase, 5);

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

        bulletBase.transform.DOPath(path, 2, PathType.CatmullRom, gizmoColor: Color.red).SetLookAt(0.1f).SetEase(Ease.OutSine).SetUpdate(UpdateType.Fixed);
    }
}

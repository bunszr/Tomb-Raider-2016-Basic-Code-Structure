using UnityEngine;

public class SingleShot : ShootBehaviourBase
{
    [System.Serializable]
    public class SingleShotData
    {
        public float unnecessary;
    }

    public SingleShotData data;

    public SingleShot(IWeapon _weapon, SingleShotData data) : base(_weapon)
    {
        this.data = data;
    }

    public override void OnUpdate()
    {
        if (Input.GetMouseButtonDown(0) && _weapon.GetAmmoData().CurrAmmoRP.Value > 0)
        {
            _weapon.Fire();
            _weapon.GetAmmoData().CurrAmmoRP.Value--;
        }
    }
}
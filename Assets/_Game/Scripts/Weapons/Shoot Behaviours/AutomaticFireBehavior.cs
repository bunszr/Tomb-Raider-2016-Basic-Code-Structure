using UnityEngine;

public class AutomaticFireBehavior : ShootBehaviourBase, IFireBehaviour
{
    [System.Serializable]
    public class AutomaticFireBehaviorData
    {
        public float delay = .2f;
    }

    public AutomaticFireBehavior(IWeapon _weapon, AutomaticFireBehaviorData data) : base(_weapon)
    {
        this.data = data;
    }

    public AutomaticFireBehaviorData data;
    float nextTime;

    public override void Enter()
    {
        base.Enter();
        nextTime = Time.time;
    }

    public override void OnUpdate()
    {
        if (Input.GetMouseButton(0) && _weapon.GetAmmoData().CurrAmmoRP.Value > 0 && nextTime < Time.time)
        {
            nextTime = Time.time + data.delay;
            _weapon.Fire();
            _weapon.GetAmmoData().CurrAmmoRP.Value--;
        }
    }
}
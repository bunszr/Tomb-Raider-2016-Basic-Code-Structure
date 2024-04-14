using UnityEngine;

public class BurstFire : ShootBehaviourBase, IFireBehaviour
{
    public BurstFire(IWeapon _weapon) : base(_weapon)
    {
    }

    public override void OnUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            _weapon.Fire();
        }
    }
}

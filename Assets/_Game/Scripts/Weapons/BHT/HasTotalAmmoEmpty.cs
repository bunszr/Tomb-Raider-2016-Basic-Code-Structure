using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Weapon
{
    public class HasTotalAmmoEmpty : Conditional
    {
        IWeapon _weapon;

        public override void OnStart()
        {
            _weapon = transform.parent.GetComponentInChildren<IWeapon>();
        }

        public override TaskStatus OnUpdate()
        {
            return _weapon.GetAmmoData().TotalAmmoRP.Value <= 0 ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
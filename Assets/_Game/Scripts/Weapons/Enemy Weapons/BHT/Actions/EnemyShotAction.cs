using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

namespace EnemyNamescape.BHT
{
    public class EnemyShotAction : Action
    {
        [SerializeField] SharedTransform weaponModelTransform;
        [SerializeField] SharedTransform weaponBaseInstallerTransform;
        [SerializeField] SharedGameObject enemyTarget;

        IWeapon _weapon;

        public override void OnAwake()
        {
            _weapon = weaponBaseInstallerTransform.Value.GetComponent<WeaponBaseInstaller>() as IWeapon;
        }

        public override void OnStart()
        {
            _weapon.Equip();
        }

        public override void OnEnd()
        {
            _weapon.Unequip();
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Running;
        }
    }
}
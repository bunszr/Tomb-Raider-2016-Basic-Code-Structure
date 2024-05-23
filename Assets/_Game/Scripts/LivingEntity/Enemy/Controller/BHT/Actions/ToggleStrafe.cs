using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

namespace EnemyNamescape.BHT
{
    public class ToggleStrafe : Action
    {
        [SerializeField] bool isStrafe;

        public override void OnStart()
        {
            IThirdPersonController _thirdPersonController = (Owner.GetVariable(EnemyStaticData.BHTKey.ThirdPersonControllerGo) as SharedGameObject).Value.GetComponent<IThirdPersonController>();
            _thirdPersonController.IsStrafe = isStrafe;
        }
    }
}
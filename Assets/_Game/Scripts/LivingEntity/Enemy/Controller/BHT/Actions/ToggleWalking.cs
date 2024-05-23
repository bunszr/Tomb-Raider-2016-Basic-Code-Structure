using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

namespace EnemyNamescape.BHT
{
    public class ToggleWalking : Action
    {
        [SerializeField] bool isWalking;

        public override void OnStart()
        {
            IThirdPersonController _thirdPersonController = (Owner.GetVariable(EnemyStaticData.BHTKey.ThirdPersonControllerGo) as SharedGameObject).Value.GetComponent<IThirdPersonController>();
            _thirdPersonController.IsWalking = isWalking;
        }
    }
}
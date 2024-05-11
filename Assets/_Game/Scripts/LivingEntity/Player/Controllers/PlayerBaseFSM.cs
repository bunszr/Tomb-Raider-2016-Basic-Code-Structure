using UnityEngine;
using FSM;

namespace CharacterPlayer
{
    public abstract class PlayerBaseFSM : MonoBehaviour
    {
        protected Camera cam;
        protected StateMachine fsm;
        [SerializeField] protected Player player;

        [SerializeField] StateMachine.StateMachineDebug stateMachineDebug;

        protected virtual void Awake()
        {
            fsm = new StateMachine(this) { stateMachineDebug = stateMachineDebug };
            cam = Camera.main;
        }

        protected virtual void Start() { }

        protected virtual void Update()
        {
            if (fsm != null) fsm.OnLogic();
        }
    }
}
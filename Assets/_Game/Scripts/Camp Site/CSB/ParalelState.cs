using FSM;

namespace CampSite
{
    public class ParalelState : StateBase
    {
        IStateBaseMine[] stateBaseMines;

        public ParalelState(bool needsExitTime, bool isGhostState = false, params IStateBaseMine[] stateBaseMines) : base(needsExitTime, isGhostState)
        {
            this.stateBaseMines = stateBaseMines;
        }

        public override void Init()
        {
            for (int i = 0; i < stateBaseMines.Length; i++) stateBaseMines[i].Init();
        }

        public override void OnEnter()
        {
            for (int i = 0; i < stateBaseMines.Length; i++) stateBaseMines[i].OnEnter();
        }

        public override void OnLogic()
        {
            for (int i = 0; i < stateBaseMines.Length; i++) stateBaseMines[i].OnLogic();
        }

        public override void OnExit()
        {
            for (int i = 0; i < stateBaseMines.Length; i++) stateBaseMines[i].OnExit();
        }
    }
}
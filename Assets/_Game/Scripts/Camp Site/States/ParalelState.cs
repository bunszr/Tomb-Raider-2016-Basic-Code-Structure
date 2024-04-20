using FSM;

namespace CampSite
{
    public class ParalelState : StateBase
    {
        StateBase[] stateBases;

        public ParalelState(StateBase[] stateBases, bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            this.stateBases = stateBases;
        }

        public override void Init()
        {
            for (int i = 0; i < stateBases.Length; i++) stateBases[i].Init();
        }

        public override void OnEnter()
        {
            for (int i = 0; i < stateBases.Length; i++) stateBases[i].OnEnter();
        }

        public override void OnExit()
        {
            for (int i = 0; i < stateBases.Length; i++) stateBases[i].OnExit();
        }
    }
}
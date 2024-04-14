using UnityEngine;

namespace CampSite
{
    public class ResetState : CampSiteButtonStateBase
    {
        public ResetState(MonoBehaviour mono, bool needsExitTime) : base(mono, needsExitTime)
        {
        }

        public override void Init()
        {

        }

        public override void OnEnter()
        {
            transform.SetLocalPosZ(0);
        }

        public override void OnLogic()
        {
            fsm.StateCanExit();
        }
    }
}
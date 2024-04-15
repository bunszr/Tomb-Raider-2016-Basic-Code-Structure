using UnityEngine;

namespace CampSite
{
    public class ResetState : CSBStateBase
    {
        public ResetState(CampSiteButtonBase csbBase, bool needsExitTime) : base(csbBase, needsExitTime)
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
using FSM;
using UnityEngine;

namespace CampSite
{
    public abstract class CampSiteButtonStateBase : StateBase
    {
        protected MonoBehaviour mono;
        protected Transform transform => mono.transform;
        protected CampSiteButtonBase csbBase;
        protected ButtonEvents buttonEvents;
        protected CampSiteHolder campSiteHolder;

        protected CampSiteButtonStateBase(MonoBehaviour mono, bool needsExitTime = false, bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            this.mono = mono;
        }
    }
}
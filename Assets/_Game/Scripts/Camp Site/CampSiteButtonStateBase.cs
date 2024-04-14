using FSM;
using UnityEngine;

namespace CampSite
{
    public abstract class CampSiteButtonStateBase : StateBase
    {
        public MonoBehaviour mono;
        public Transform transform => mono.transform;

        public CampSiteButtonStateBase(MonoBehaviour mono, bool needsExitTime) : base(needsExitTime)
        {
            this.mono = mono;
        }
    }
}
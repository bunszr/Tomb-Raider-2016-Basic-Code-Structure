using UnityEngine;

namespace CampSite
{
    public class ClickState : CampSiteButtonStateBase
    {
        [System.Serializable]
        public class ClickStateData
        {
            public Canvas nextCanvas;
        }

        ClickStateData data;

        public ClickState(MonoBehaviour mono, bool needsExitTime, ClickStateData data) : base(mono, needsExitTime)
        {
            this.data = data;
        }

        public override void Init()
        {
        }

        public override void OnEnter()
        {
            transform.GetComponentInParent<Canvas>().gameObject.SetActive(false);
            data.nextCanvas.gameObject.SetActive(true);
        }
    }
}
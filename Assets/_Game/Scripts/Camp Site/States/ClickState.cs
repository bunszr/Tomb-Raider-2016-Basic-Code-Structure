using UnityEngine;

namespace CampSite
{
    public class ClickState : CSBStateBase
    {
        [System.Serializable]
        public class ClickStateData
        {
            public Canvas nextCanvas;
        }

        ClickStateData data;

        public ClickState(CampSiteButtonBase csbBase, bool needsExitTime, ClickStateData data) : base(csbBase, needsExitTime)
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
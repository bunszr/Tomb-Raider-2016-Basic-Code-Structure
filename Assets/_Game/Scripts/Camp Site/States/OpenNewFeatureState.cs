using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace CampSite
{
    public class OpenNewFeatureState : CSBStateBase
    {
        [System.Serializable]
        public class OpenNewFeatureStateData
        {
            public Canvas nextCanvas;
        }

        OpenNewFeatureStateData data;

        public OpenNewFeatureState(CampSiteButtonBase csbBase, bool needsExitTime, OpenNewFeatureStateData data) : base(csbBase, needsExitTime)
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
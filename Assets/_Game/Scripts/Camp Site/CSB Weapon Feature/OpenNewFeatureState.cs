using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace CampSite
{
    public class OpenNewFeatureState : CampSiteButtonStateBase
    {
        [System.Serializable]
        public class OpenNewFeatureStateData
        {
            public Canvas nextCanvas;
        }

        Vector3 vel;
        Quaternion defaultRot;

        Tween tween;
        Tween tweenRot;
        OpenNewFeatureStateData data;
        Camera cam;
        CinemachineVirtualCamera virtualCamera;

        public OpenNewFeatureState(MonoBehaviour mono, bool needsExitTime, OpenNewFeatureStateData data) : base(mono, needsExitTime)
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
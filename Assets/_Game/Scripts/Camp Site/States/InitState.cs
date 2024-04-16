using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

namespace CampSite
{
    public class InitState : CSBStateBase
    {
        [System.Serializable]
        public class InitStateData
        {
            public Image imageToHighlight;
            public float duration = .4f;
        }

        CinemachineBrain brain;
        CinemachineVirtualCamera virtualCamera;

        public InitState(CampSiteButtonBase csbBase, bool needsExitTime, CinemachineBrain brain) : base(csbBase, needsExitTime)
        {
            this.brain = brain;
        }

        public override void Init()
        {
            virtualCamera = transform.GetComponentInParent<Canvas>().GetComponentInChildren<CinemachineVirtualCamera>();
        }

        public override void OnEnter()
        {
            csbBase.StartCoroutine(ActivateVirtualCameraIE());
        }

        public override void OnLogic()
        {
            fsm.StateCanExit();
        }

        IEnumerator ActivateVirtualCameraIE() // ActiveVirtualCamera is null in the first frame if scene is loaded again.
        {
            while (brain.ActiveVirtualCamera == null) yield return null;
            virtualCamera.Priority = brain.ActiveVirtualCamera.Priority + 1;
        }
    }
}
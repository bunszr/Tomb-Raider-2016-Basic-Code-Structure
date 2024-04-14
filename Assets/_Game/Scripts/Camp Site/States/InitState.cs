using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CampSite
{
    public class InitState : CampSiteButtonStateBase
    {
        [System.Serializable]
        public class InitStateData
        {
            public Image imageToHighlight;
            public float duration = .4f;
        }

        CinemachineBrain brain;
        CinemachineVirtualCamera virtualCamera;

        public InitState(MonoBehaviour mono, bool needsExitTime, CinemachineBrain brain) : base(mono, needsExitTime)
        {
            this.brain = brain;
        }

        public override void Init()
        {
            virtualCamera = transform.GetComponentInParent<Canvas>().GetComponentInChildren<CinemachineVirtualCamera>();
        }

        public override void OnEnter()
        {
            virtualCamera.Priority = brain.ActiveVirtualCamera.Priority + 1;
        }

        public override void OnLogic()
        {
            fsm.StateCanExit();
        }
    }
}
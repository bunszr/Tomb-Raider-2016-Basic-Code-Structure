using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class WeaponRotationState : IStateBaseMine
    {
        [System.Serializable]
        public class WeaponRotationStateData
        {
            [OnValueChanged("SetLocalRotation")] public Quaternion localRotation;
            [OnValueChanged("SetLocalPosition")] public Vector3 localPosition;
#if UNITY_EDITOR
            public void SetLocalRotation() => GameObject.FindObjectOfType<CampSiteHolder>().WeaponShowLocation.localRotation = localRotation;
            public void SetLocalPosition() => GameObject.FindGameObjectWithTag("FeatureIndicatorSprite").transform.localPosition = localPosition;
#endif
        }

        ButtonEvents buttonEvents;
        WeaponRotationStateData data;
        CampSiteHolder campSiteHolder;


        public WeaponRotationState(ButtonEvents buttonEvents, CampSiteHolder campSiteHolder, WeaponRotationStateData data)
        {
            this.data = data;
            this.buttonEvents = buttonEvents;
            this.campSiteHolder = campSiteHolder;
        }

        public void Init()
        {
        }

        public void OnEnter()
        {
            buttonEvents.onPointerEnterEvent += OnPointerEnter;
            buttonEvents.onPointerExitEvent += OnPointerExit;
        }

        public void OnExit()
        {
            buttonEvents.onPointerEnterEvent -= OnPointerEnter;
            buttonEvents.onPointerExitEvent -= OnPointerExit;
        }

        void OnPointerEnter(PointerEventData eventData)
        {
            campSiteHolder.WeaponShowLocation.DOKill();
            campSiteHolder.WeaponFeatureIndicator.DOKill();

            campSiteHolder.WeaponShowLocation.DOLocalRotateQuaternion(data.localRotation, .2f);
            campSiteHolder.WeaponFeatureIndicator.DOLocalMove(data.localPosition, .2f);
        }

        void OnPointerExit(PointerEventData eventData)
        {
        }

        public void OnLogic()
        {
        }

    }
}
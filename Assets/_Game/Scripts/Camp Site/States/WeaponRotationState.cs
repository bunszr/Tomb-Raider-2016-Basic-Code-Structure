using DG.Tweening;
using FSM;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class WeaponRotationState : CSBParalelStateBase
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

        WeaponRotationStateData data;

        public WeaponRotationState(MonoBehaviour mono, WeaponRotationStateData data) : base(mono)
        {
            this.data = data;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            campSiteHolder.WeaponShowLocation.DOKill();
            campSiteHolder.WeaponFeatureIndicator.DOKill();

            campSiteHolder.WeaponShowLocation.DOLocalRotateQuaternion(data.localRotation, .2f);
            campSiteHolder.WeaponFeatureIndicator.DOLocalMove(data.localPosition, .2f);
        }

        protected override void OnPointerExit(PointerEventData eventData) { }
    }
}
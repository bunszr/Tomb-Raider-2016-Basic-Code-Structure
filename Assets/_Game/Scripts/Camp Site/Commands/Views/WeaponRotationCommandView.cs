using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class WeaponRotationCommandView : CampsiteButtonCommandBase
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
        CampSiteHolder campSiteHolder;

        public WeaponRotationCommandView(CSBBase csbBase, WeaponRotationStateData data, CampSiteHolder campSiteHolder) : base(csbBase)
        {
            this.data = data;
            this.campSiteHolder = campSiteHolder;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            campSiteHolder.WeaponShowLocation.DOKill();
            campSiteHolder.WeaponFeatureIndicator.DOKill();

            campSiteHolder.WeaponShowLocation.DOLocalRotateQuaternion(data.localRotation, .2f);
            campSiteHolder.WeaponFeatureIndicator.DOLocalMove(data.localPosition, .2f);
        }
    }
}
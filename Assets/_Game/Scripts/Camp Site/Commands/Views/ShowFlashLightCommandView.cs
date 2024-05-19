using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowFlashLightCommandView : CampsiteButtonCommandBase
    {
        [System.Serializable]
        public class ShowFlashLightCommandViewData
        {
            public float lightToggleDelay = .5f;
            public float obstacleDistance = 2f;
        }

        GameObject weaponHolder;
        Vector3 addOnDefaultlocalPos;
        Tween flashTween;
        IFlashLightAddOn _flashLightAddOn;
        GameObject obstacleForShowingLight;
        ShowFlashLightCommandViewData data;

        public ShowFlashLightCommandView(CSBBase csbBase, GameObject weaponHolder, ShowFlashLightCommandViewData data) : base(csbBase)
        {
            this.weaponHolder = weaponHolder;

            obstacleForShowingLight = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obstacleForShowingLight.name = "obstacleForShowingLight";
            obstacleForShowingLight.transform.parent = weaponHolder.transform;
            obstacleForShowingLight.gameObject.SetActive(false);
            obstacleForShowingLight.transform.localScale = new Vector3(1, 1, .1f);
            this.data = data;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            _flashLightAddOn = weaponHolder.GetComponentInChildren<IFlashLightAddOn>();
            addOnDefaultlocalPos = _flashLightAddOn.FlashLightAddOnData.addOn.transform.localPosition;
            _flashLightAddOn.FlashLightAddOnData.addOn.SetActive(true);
            _flashLightAddOn.FlashLightAddOnData.addOn.transform.DOLocalMoveZ(.4f, .3f).From(true);
            flashTween = DOVirtual.DelayedCall(data.lightToggleDelay, OnFlash).SetLoops(-1);

            obstacleForShowingLight.gameObject.SetActive(true);
            obstacleForShowingLight.transform.position = _flashLightAddOn.FlashLightAddOnData.light.transform.position + _flashLightAddOn.FlashLightAddOnData.light.transform.forward * data.obstacleDistance;
            obstacleForShowingLight.transform.rotation = _flashLightAddOn.FlashLightAddOnData.light.transform.rotation;
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            _flashLightAddOn.FlashLightAddOnData.addOn.transform.DOKill();
            _flashLightAddOn.FlashLightAddOnData.addOn.SetActive(false);
            _flashLightAddOn.FlashLightAddOnData.addOn.transform.localPosition = addOnDefaultlocalPos;
            flashTween.KillMine();

            obstacleForShowingLight.gameObject.SetActive(false);
        }

        void OnFlash() => _flashLightAddOn.FlashLightAddOnData.light.enabled = !_flashLightAddOn.FlashLightAddOnData.light.enabled;
    }
}
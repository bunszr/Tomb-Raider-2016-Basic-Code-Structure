using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowFlashLightAfterOpenCommandView : CampsiteButtonCommandBase
    {
        GameObject weaponHolder;
        Vector3 addOnDefaultlocalPos;
        Tween flashTween;
        IFlashLightAddOn _flashLightAddOn;
        GameObject obstacleForShowingLight;

        public ShowFlashLightAfterOpenCommandView(CSBBase csbBase, GameObject weaponHolder) : base(csbBase)
        {
            this.weaponHolder = weaponHolder;

            obstacleForShowingLight = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obstacleForShowingLight.name = "obstacleForShowingLight";
            obstacleForShowingLight.transform.parent = weaponHolder.transform;
            obstacleForShowingLight.gameObject.SetActive(false);
            obstacleForShowingLight.transform.localScale = new Vector3(1, 1, .1f);
        }

        // public override void OnDeactivate()
        // {
        //     base.OnDeactivate();
        //     obstacleForShowingLight.gameObject.SetActive(false);
        // }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            _flashLightAddOn = weaponHolder.GetComponentInChildren<IFlashLightAddOn>();
            addOnDefaultlocalPos = _flashLightAddOn.FlashLightAddOnData.addOn.transform.localPosition;
            _flashLightAddOn.FlashLightAddOnData.addOn.SetActive(true);

            obstacleForShowingLight.gameObject.SetActive(true);
            obstacleForShowingLight.transform.position = _flashLightAddOn.FlashLightAddOnData.light.transform.position + _flashLightAddOn.FlashLightAddOnData.light.transform.forward * 2;
            obstacleForShowingLight.transform.rotation = _flashLightAddOn.FlashLightAddOnData.light.transform.rotation;
            _flashLightAddOn.FlashLightAddOnData.light.enabled = true;
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            _flashLightAddOn.FlashLightAddOnData.addOn.transform.DOKill();
            _flashLightAddOn.FlashLightAddOnData.addOn.SetActive(false);
            flashTween.KillMine();

            _flashLightAddOn.FlashLightAddOnData.light.enabled = false;
            obstacleForShowingLight.gameObject.SetActive(false);
        }
    }
}
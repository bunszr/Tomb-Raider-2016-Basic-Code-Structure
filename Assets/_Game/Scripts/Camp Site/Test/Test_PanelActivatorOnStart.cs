using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CampSite
{
    public class Test_PanelActivatorOnStart : MonoBehaviour
    {
        public GameObject panelToActivate;

        IEnumerator Start()
        {
            yield return null;
            yield return null;
            if (panelToActivate != null) panelToActivate.GetComponent<IPanelToggler>().Active();

            PressButton();
        }

        [Title("Call OnClick Method")]
        [SerializeField] CSBBaseController cSBBaseController;
        [SerializeField] bool activateAndPressButton;

        public void PressButton()
        {
            if (activateAndPressButton && cSBBaseController != null) cSBBaseController.OnPointerClick(null);
        }
    }
}
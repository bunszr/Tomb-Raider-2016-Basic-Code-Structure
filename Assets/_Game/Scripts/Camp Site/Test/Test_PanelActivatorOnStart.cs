using System.Collections;
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
        }
    }
}
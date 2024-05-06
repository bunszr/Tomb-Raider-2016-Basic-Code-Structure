using UnityEngine;

namespace CampSite
{
    public class Test_PanelActivatorWithPressKey : MonoBehaviour
    {
        public GameObject panelToActivate;
        public KeyCode keyCode = KeyCode.Y;
#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(keyCode) && panelToActivate != null) panelToActivate.GetComponent<IPanelToggler>().Active();
        }
#endif
    }
}

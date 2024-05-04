using UnityEngine;

namespace CampSite
{
    public class CSPanelActivatorWithPressKeyInEditor : MonoBehaviour
    {
#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Y)) GetComponent<IPanelToggler>().Active();
        }
#endif
    }
}

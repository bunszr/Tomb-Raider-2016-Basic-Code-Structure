using UnityEngine;

namespace CampSite
{
    public class ToggleActivationGameObjectCommand : ICSBExecute
    {
        GameObject gameObject;
        bool isActive;

        public ToggleActivationGameObjectCommand(GameObject gameObject, bool isActive)
        {
            this.gameObject = gameObject;
            this.isActive = isActive;
        }

        public void Execute() => gameObject.SetActive(isActive);
    }
}
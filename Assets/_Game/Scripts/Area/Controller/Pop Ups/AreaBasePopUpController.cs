using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaBasePopUpController : MonoBehaviour
    {
        protected TriggerCustom triggerCustom;
        [SerializeField] protected AreaBase areaBase;

        protected virtual void Start() => triggerCustom = gameObject.GetOrAddComponent<TriggerCustom>();
    }
}
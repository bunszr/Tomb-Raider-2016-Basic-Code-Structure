using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaBaseController : MonoBehaviour
    {
        protected TriggerCustom triggerCustom;
        protected CommandExecuter commandExecuter;

        [SerializeField] protected AreaBase areaBase;
        [SerializeField] protected CommandExecuter.CommandExecuterDebug commandExecuterDebug;
        public TriggeredPlayerReference TriggeredPlayerReference { get; private set; } = new TriggeredPlayerReference();

        protected virtual void Start() => triggerCustom = gameObject.GetOrAddComponent<TriggerCustom>();
        protected virtual void OnFinishedExecutionOfCommands() { }
    }
}
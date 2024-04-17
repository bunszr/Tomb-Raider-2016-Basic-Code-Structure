using Sirenix.OdinInspector;
using UnityEngine;

[InlineEditor]
public abstract class RequirementsScriptableBase : ScriptableObject
{
    [SerializeField, Multiline] string description;

    public string Description { get => description; }

    public abstract bool IsTrue();
}
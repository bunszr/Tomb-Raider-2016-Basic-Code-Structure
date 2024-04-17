using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

[InlineEditor]
public abstract class FeatureTypeScriptable : ScriptableObject
{
    [SerializeField, ReadOnly] int hash;
    [SerializeField] bool isOpen = true;
    [SerializeField] RequirementsScriptableBase[] requirementsScriptableBases;

    public int Hash { get => hash; }
    public bool IsOpen { get => isOpen; }
    public ReactiveProperty<bool> IsOpenRP { get; private set; }
    public RequirementsScriptableBase[] RequirementsScriptableBases { get => requirementsScriptableBases; }

    public void Load(bool isOpenPram) => IsOpenRP = new ReactiveProperty<bool>(isOpenPram);

#if UNITY_EDITOR
    private void Awake()
    {
        hash = GetInstanceID();
    }
#endif
}
using System.Linq;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

[InlineEditor]
public abstract class FeatureTypeScriptable : ScriptableObject
{
    [SerializeField, ReadOnly] int hash;
    [SerializeField] string featureName;
    [SerializeField] string description;
    [SerializeField] bool isOpen = true;
    [SerializeField] RequirementsScriptableBase[] requirementsScriptableBases;

    public int Hash { get => hash; }
    [ReadOnly, ShowInInspector] public ReactiveProperty<bool> IsOpenRP { get; private set; }
    public RequirementsScriptableBase[] RequirementsScriptableBases { get => requirementsScriptableBases; }
    public string FeatureName { get => featureName; }
    public string Description { get => description; }

    public void Load(bool isOpenPram) => IsOpenRP = new ReactiveProperty<bool>(isOpenPram);
    public void LoadFromItSelf() => IsOpenRP = new ReactiveProperty<bool>(isOpen);

    [Button]
    public bool AreRequirementsDone()
    {
        if (requirementsScriptableBases.Length == 0) return true;
        return requirementsScriptableBases.All(x => x.IsTrue());
    }

#if UNITY_EDITOR
    private void Awake()
    {
        hash = GetInstanceID();
    }
#endif
}
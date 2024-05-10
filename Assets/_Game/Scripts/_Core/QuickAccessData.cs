using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "QuickAccessData", menuName = "Third-Person-Shooter/For Editor/QuickAccess", order = 0)]
[InlineEditor(InlineEditorObjectFieldModes.Hidden, Expanded = true)]
public class QuickAccessData : ScriptableObject
{
    [HorizontalGroup("C")] public Object[] objectsA;
    [HorizontalGroup("C")] public Object[] objectsB;
}

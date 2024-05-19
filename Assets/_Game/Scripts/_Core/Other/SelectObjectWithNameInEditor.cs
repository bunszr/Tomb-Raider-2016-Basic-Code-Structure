using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using System.Linq;

[System.Serializable]
public class SelectObjectWithComponentNameInEditor
{
#if UNITY_EDITOR
    [SerializeField, HorizontalGroup("T"), HideLabel, InlineButton("SM"), InlineButton("S", "Select")] string name = "Enter Name";
    void S() => Selection.activeObject = GameObject.FindObjectsOfType<Component>(true).FirstOrDefault(x => x.GetType().Name == name);
    void SM() => Selection.objects = GameObject.FindObjectsOfType<Component>(true).Where(x => x.GetType().Name == name).Select(x => (Object)x.gameObject).ToArray();
#endif
}
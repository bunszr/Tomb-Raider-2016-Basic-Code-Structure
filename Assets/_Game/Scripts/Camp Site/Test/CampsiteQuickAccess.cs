using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using CampSite;
using Cinemachine;
using System.Linq;

[CreateAssetMenu(fileName = "CampsiteQuickAccess", menuName = "Third-Person-Shooter/For Editor/CampsiteQuickAccess", order = 0)]
public class CampsiteQuickAccess : ScriptableObject
{
    [HorizontalGroup("C")] public Object[] objectsA;
    [HorizontalGroup("C")] public Object[] objectsB;

    [SerializeField, HorizontalGroup("Select")] SelectClass[] selectClass;
    [SerializeField, HorizontalGroup("Select")] SelectClass[] selectClass2;

    [System.Serializable]
    public class SelectClass
    {
        [SerializeField, HorizontalGroup("T"), HideLabel, InlineButton("SM"), InlineButton("S", "Select")] string name = "CSBSkillFeature";
        void S() => Selection.activeObject = FindObjectsOfType<Component>().FirstOrDefault(x => x.GetType().Name == name);
        void SM() => Selection.objects = FindObjectsOfType<Component>().Where(x => x.GetType().Name == name).Select(x => (Object)x.gameObject).ToArray();
    }

    [Button, HorizontalGroup("6")]
    public void DisableCameras()
    {
        FindObjectOfType<CampSiteHolder>().GetComponentsInChildren<CinemachineVirtualCamera>().Foreach(x =>
        {
            x.gameObject.SetActive(false);
            // x.Priority.SetActive(false);
        });
    }
}
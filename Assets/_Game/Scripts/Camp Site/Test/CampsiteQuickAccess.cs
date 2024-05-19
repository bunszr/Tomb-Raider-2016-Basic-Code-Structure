using UnityEngine;
using Sirenix.OdinInspector;
using CampSite;
using Cinemachine;

[CreateAssetMenu(fileName = "CampsiteQuickAccess", menuName = "Third-Person-Shooter/For Editor/CampsiteQuickAccess", order = 0)]
public partial class CampsiteQuickAccess : ScriptableObject
{
    [HorizontalGroup("C")] public Object[] objectsA;
    [HorizontalGroup("C")] public Object[] objectsB;

    [SerializeField, HorizontalGroup("Select")] SelectObjectWithComponentNameInEditor[] selectClass;
    [SerializeField, HorizontalGroup("Select")] SelectObjectWithComponentNameInEditor[] selectClass2;

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
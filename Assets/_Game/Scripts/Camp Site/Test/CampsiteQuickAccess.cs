using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using CampSite;
using Cinemachine;

[CreateAssetMenu(fileName = "CampsiteQuickAccess", menuName = "Third-Person-Shooter/For Editor/CampsiteQuickAccess", order = 0)]
public class CampsiteQuickAccess : ScriptableObject
{
    [HorizontalGroup("C")] public Object[] objectsA;
    [HorizontalGroup("C")] public Object[] objectsB;

    [Button, HorizontalGroup("5")] public void CSBWeaponFeature() => Selection.activeGameObject = FindObjectOfType<CSBWeaponFeature>().gameObject;
    [Button, HorizontalGroup("5")] public void CSBFirstLevel() => Selection.activeGameObject = FindObjectOfType<CSBFirstLevel>().gameObject;
    [Button, HorizontalGroup("5")] public void CSBWeaponSelector() => Selection.activeGameObject = FindObjectOfType<CSBWeaponSelector>().gameObject;

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
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using CampSite;
using Cinemachine;
using WeaponNamescape.Enemy;

[CreateAssetMenu(fileName = "WeaponQuickAccess", menuName = "Third-Person-Shooter/For Editor/WeaponQuickAccess", order = 0)]
public class WeaponQuickAccess : ScriptableObject
{
    [HorizontalGroup("C")] public Object[] objectsA;
    [HorizontalGroup("C")] public Object[] objectsB;

    [SerializeField, HorizontalGroup("Select")] SelectObjectWithComponentNameInEditor[] selectClass;
    [SerializeField, HorizontalGroup("Select")] SelectObjectWithComponentNameInEditor[] selectClass2;

    [Button, HorizontalGroup("5")] public void SelectPistol() => Selection.activeGameObject = FindObjectOfType<Pistol>(true).gameObject;
    [Button, HorizontalGroup("5")] public void SelectPistolEnemy() => Selection.activeGameObject = FindObjectOfType<PistolEnemy>(true).gameObject;

    [SerializeField, HorizontalGroup("Inst")] GameObject prefab;
    [Button, HorizontalGroup("Inst")] public void Instantiate() => GameObject.Instantiate(prefab);
}
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using System.Linq;
using DG.Tweening;
using System.IO;
using CampSite;

public class QuickAccess : OdinEditorWindow
{
    [HorizontalGroup("C")] public Object[] objectsA;
    [HorizontalGroup("C")] public Object[] objectsB;

    [MenuItem("Tools/QuickAccess")]
    public static void ShowWindow()
    {
        GetWindow(typeof(QuickAccess));
    }

    [FoldoutGroup("Other")]
    public string typeName = "Obstacle";
    [Button, FoldoutGroup("Other")]
    public void SelectWithComponent()
    {
        Selection.objects = FindObjectsOfType<Component>().Where(x => x.GetType().Name == typeName).Select(x => (Object)x.gameObject).ToArray(); // If we write x instead of x.gameObject, it only selects that component. This kind of Transform selects together with meshFilter etc.
    }

    [Button, FoldoutGroup("Other")]
    public void SelectWithName()
    {
        Selection.objects = FindObjectsOfType<GameObject>().Where(x => x.name == typeName).Select(x => (Object)x.gameObject).ToArray();
    }

    [Button, HorizontalGroup("4")]
    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    [Button, HorizontalGroup("4")]
    public void DeleteFiles()
    {
        DeletePrefs();
        foreach (string filePath in Directory.GetFiles(Application.persistentDataPath)) File.Delete(filePath);
    }

    [Button, HorizontalGroup("4")]
    public void PrintPersistentDataPath()
    {
        Debug.Log(Application.persistentDataPath);
    }

    [Button, HorizontalGroup("4")]
    public void DeleteAllPersist()
    {
        DeletePrefs();
        foreach (string filePath in Directory.GetFiles(Application.persistentDataPath)) File.Delete(filePath);
        foreach (string dir in Directory.GetDirectories(Application.persistentDataPath)) Directory.Delete(dir, true);
    }

    [Button(ButtonSizes.Small), HorizontalGroup("B")] public void x1() => Time.timeScale = 1;
    [Button(ButtonSizes.Small), HorizontalGroup("B")] public void x2() => Time.timeScale = 3;
    [Button(ButtonSizes.Small), HorizontalGroup("B")] public void x6() => Time.timeScale = 6;
    [Button(ButtonSizes.Small), HorizontalGroup("B")] public void x12() => Time.timeScale = 12;

    [Button, HorizontalGroup("5")]
    public void SelectCSB()
    {
        Selection.activeGameObject = FindObjectOfType<CSBWeaponFeature>().gameObject;
    }

    [Button, HorizontalGroup("5")]
    public void SelectPistol()
    {
        Selection.activeGameObject = FindObjectOfType<Pistol>(true).gameObject;
    }

    [Button, HorizontalGroup("5")]
    public void ToogleLoadJSON()
    {
        GameDataScriptable.Ins.loadWeaponDataFromJSONinEditor = !GameDataScriptable.Ins.loadWeaponDataFromJSONinEditor;
        GameDataScriptable.Ins.loadFeatureFromJSONinEditor = !GameDataScriptable.Ins.loadFeatureFromJSONinEditor;
        GameDataScriptable.Ins.loadInventoryFromJSONinEditor = !GameDataScriptable.Ins.loadInventoryFromJSONinEditor;
    }


    // [Button(ButtonSizes.Small), HorizontalGroup("A")]
    // public void SaveShatter()
    // {
    //     foreach (var item in FindObjectsOfType<RayFire.RayfireShatter>(true))
    //     {
    //         EditorUtility.SetDirty(item);
    //     }
    // }
}
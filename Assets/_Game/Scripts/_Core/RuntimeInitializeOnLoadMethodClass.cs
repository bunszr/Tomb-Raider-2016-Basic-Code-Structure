using CampSite;
using Inventory;
using UnityEngine;

class RuntimeInitializeOnLoadMethodClass
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void BeforeSceneLoad()
    {
        CreateFeatureSaverAndLoader();
        CreateInventorySaverAndLoader();
    }

    static void CreateFeatureSaverAndLoader()
    {
        GameObject go = new GameObject("FeatureSaverAndLoader", typeof(FeatureSaverAndLoader));
        GameObject.DontDestroyOnLoad(go);
    }

    static void CreateInventorySaverAndLoader()
    {
        GameObject go = new GameObject("InventorySaverAndLoader", typeof(InventorySaverAndLoader));
        GameObject.DontDestroyOnLoad(go);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnAfterSceneLoad()
    {
        GameObject go = new GameObject("Shortcut Mono", typeof(ShortCutMono));
        GameObject.DontDestroyOnLoad(go);
    }
}
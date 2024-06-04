using CampSite;
using Inventory;
using UnityEngine;

class RuntimeInitializeOnLoadMethodClass
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void BeforeSceneLoad()
    {
        CreateFeatureSaverAndLoader<FeatureSaverAndLoader>();
        CreateFeatureSaverAndLoader<InventorySaverAndLoader>();
        CreateFeatureSaverAndLoader<WeaponSaverAndLoader>();
        CreateFeatureSaverAndLoader<PlayerDataSaverAndLoader>();
    }

    static void CreateFeatureSaverAndLoader<T>() where T : Component
    {
        GameObject go = new GameObject(typeof(T).Name, typeof(T));
        GameObject.DontDestroyOnLoad(go);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnAfterSceneLoad()
    {
        GameObject go = new GameObject("Shortcut Mono", typeof(ShortCutMono));
        GameObject.DontDestroyOnLoad(go);
    }
}
using CampSite;
using UnityEngine;

class RuntimeInitializeOnLoadMethodClass
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void BeforeSceneLoad()
    {
        GameObject go2 = new GameObject("FeatureSaverAndLoader", typeof(FeatureSaverAndLoader));
        GameObject.DontDestroyOnLoad(go2);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnAfterSceneLoad()
    {
        GameObject go = new GameObject("Shortcut Mono", typeof(ShortCutMono));
        GameObject.DontDestroyOnLoad(go);
    }
}
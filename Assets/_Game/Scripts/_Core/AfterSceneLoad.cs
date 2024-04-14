using Sirenix.OdinInspector;
using UnityEngine;

public class AfterSceneLoad : SingletonAndDontDestroyOnLoad<AfterSceneLoad>
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnAfterSceneLoad()
    {
        GameObject go = new GameObject("Shortcut Mono", typeof(ShortCutMono));
        GameObject.DontDestroyOnLoad(go);
    }
}
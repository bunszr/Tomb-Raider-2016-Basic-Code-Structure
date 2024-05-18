using Sirenix.OdinInspector;
using UnityEngine;

// This class execute from "RuntimeInitializeOnLoadMethodClass" class

public class PlayerDataSaverAndLoader : MonoBehaviour
{
        [ReadOnly, ShowInInspector] PlayerDataScriptable[] playerDataScriptables;

        void Awake()
        {
                playerDataScriptables = Resources.LoadAll<PlayerDataScriptable>("");

#if UNITY_EDITOR
                if (!GameDataScriptable.Ins.loadPlayerDataFromJSONinEditor) LoadFromItSelf();
                else LoadFromJSON();
#else
        LoadFromJSON();
#endif
        }

        private void OnDisable() => Save();

        [Button] void Save() => playerDataScriptables.Foreach(x => x.Save());
        [Button] void LoadFromItSelf() => playerDataScriptables.Foreach(x => x.LoadFromItSelf());
        [Button] void LoadFromJSON() => playerDataScriptables.Foreach(x => x.LoadFromJson());
}
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;

namespace AdditiveSceneHelper
{
    [CreateAssetMenu(fileName = "LevelManager", menuName = "Additive Scene Helper/LevelManager", order = 0)]
    public class LevelManager : ScriptableObject
    {
        [SerializeField] Object mainScene;

        public const string MAIN_SCENE_NAME = "Main Scene";
        public const string NOT_LOOP_LEVEL_INDEX = "notLoopLevelIndex";

        [NonReorderable]
        public ScenesInfo[] sceneInfos;

        public ScenesInfo LevelSceneInfo => sceneInfos[0];

        public int LevelIndexNotLoop
        {
            get => PlayerPrefs.GetInt(NOT_LOOP_LEVEL_INDEX, 1);
            set => PlayerPrefs.SetInt(NOT_LOOP_LEVEL_INDEX, value);
        }

        public void JumpNextLevel()
        {
            ReloadScene();
        }

        public void ReloadScene()
        {
            LoadSceneAccordingInfo();
        }

        public void LoadSceneAccordingInfo()
        {
            SceneManager.LoadScene(MAIN_SCENE_NAME);
            SceneManager.LoadScene(LevelSceneInfo.CurrSceneName, LoadSceneMode.Additive);
        }

        public void IncrementLevelIndex()
        {
            LevelSceneInfo.LevelIndex = (LevelSceneInfo.LevelIndex + 1) % LevelSceneInfo.NumScenes;
            LevelIndexNotLoop += 1;
        }

        public void ShortcutUpdateMethod()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                var sceneNames = Enumerable.Range(0, SceneManager.sceneCount).Select(x => SceneManager.GetSceneAt(x).name).ToArray();

                SceneManager.LoadScene(sceneNames[0]);
                foreach (var name in sceneNames.Skip(1))
                {
                    SceneManager.LoadScene(name, LoadSceneMode.Additive);
                }
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                IncrementLevelIndex();
                JumpNextLevel();
            }
        }

        [System.Serializable]
        public class ScenesInfo
        {
            public string name;
            public string sceneFolderPath;

            [SerializeField] Object[] sceneObjects = new Object[] { };
            [HideInInspector, SerializeField] string[] sceneNames = new string[] { };

            public string[] SceneNames
            {
                get
                {
#if UNITY_EDITOR
                    sceneNames = new string[sceneObjects.Length];
                    for (int i = 0; i < sceneNames.Length; i++) sceneNames[i] = sceneObjects[i].name;
#endif
                    return sceneNames;
                }
            }

            public int NumScenes => SceneNames.Length;
            public string CurrSceneName => SceneNames[LevelIndex];
            public string CurrScenePath => sceneFolderPath + "/" + SceneNames[LevelIndex] + ".unity";
            public int SceneFolderPathHashCode => sceneFolderPath.GetHashCode();

            public int LevelIndex
            {
                get => PlayerPrefs.GetInt(name + "Key");
                // set => PlayerPrefs.SetInt(name + "Key", value);
                set
                {
                    // Debug.Log("Set " + value + "   " + name);
                    PlayerPrefs.SetInt(name + "Key", value);
                }
            }
        }
    }
}

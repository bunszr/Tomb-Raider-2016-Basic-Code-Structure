using UnityEngine;

public class ShortCutMono : Singleton<ShortCutMono>
{
#if UNITY_EDITOR
    static float space = .2f;
    static float pressTime;

    private void Update()
    {
        SOHolder.Ins.levelManager.ShortcutUpdateMethod();

        if (Time.realtimeSinceStartup - pressTime > space && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.X))
        {
            UnityEditor.EditorApplication.modifierKeysChanged += StaticUpdate;
            pressTime = Time.realtimeSinceStartup;
            Debug.Break();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            UnityEditor.EditorWindow.focusedWindow.maximized = !UnityEditor.EditorWindow.focusedWindow.maximized;
        }
    }

    private void OnDestroy()
    {
        UnityEditor.EditorApplication.modifierKeysChanged -= StaticUpdate;
    }

    static void StaticUpdate()
    {
        if (Time.realtimeSinceStartup - pressTime > space && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.X))
        {
            pressTime = Time.realtimeSinceStartup;
            UnityEditor.EditorApplication.isPaused = false;
            UnityEditor.EditorApplication.modifierKeysChanged -= StaticUpdate;
        }
    }
#endif
}
using UnityEngine;

public class SelectOnStart : MonoBehaviour
{
    private void Start()
    {
#if UNITY_EDITOR
        UnityEditor.Selection.activeGameObject = gameObject;
#endif
    }
}
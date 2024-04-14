using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

[ExecuteInEditMode]
public class BoxPositionerUpdate : MonoBehaviour
{
    public Vector3 space;
    public Vector3 offset;

    public bool isPivot = false;

#if UNITY_EDITOR
    private void Update()
    {
        if (Application.isPlaying) return;
        OnValidate();
    }

    [Button]
    private void OnValidate()
    {
        if (UnityEditor.Selection.activeGameObject == null || !UnityEditor.Selection.activeGameObject.GetComponentsInParent<Transform>().Contains(transform)) return;

        if (!gameObject.activeSelf || Application.isPlaying) return;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
            UnityEditor.Undo.RecordObject(t, "t");

            if (isPivot)
            {
                t.localPosition = offset + new Vector3(i * space.x, i * space.y, i * space.z);
            }
            else
            {
                float offsetXForCenter = (transform.childCount - 1) * space.x / 2f * -1;
                float offsetYForCenter = (transform.childCount - 1) * space.y / 2f * -1;
                float offsetZForCenter = (transform.childCount - 1) * space.z / 2f * -1;
                t.localPosition = offset + new Vector3(offsetXForCenter + i * space.x,
                                                       offsetYForCenter + i * space.y,
                                                       offsetZForCenter + i * space.z);
            }
        }
    }
#endif
}
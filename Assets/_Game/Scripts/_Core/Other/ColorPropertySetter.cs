using UnityEngine;

public class ColorPropertySetter : MonoBehaviour
{
    public Color color;

    private void Awake()
    {
        OnValidate();
    }

    public void OnValidate()
    {
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        Renderer renderer = GetComponent<Renderer>();
        propertyBlock.SetColor("_Color", color);
        renderer.SetPropertyBlock(propertyBlock);
    }
}
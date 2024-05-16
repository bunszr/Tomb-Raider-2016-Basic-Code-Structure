using UnityEngine;

public static class APLayer
{
    public static readonly string DeathLayer = "DeathLayer";
    public static readonly string DrawAndAimLayer = "DrawAndAimLayer";
    public static readonly string BaseLayer = "BaseLayer";

    public static int GetLayerIndexMine(this Animator animator, string name)
    {
        int layerIndex = animator.GetLayerIndex(name);
        if (layerIndex < 0) Debug.LogError("There is no layer by " + name);
        return layerIndex;
    }
}
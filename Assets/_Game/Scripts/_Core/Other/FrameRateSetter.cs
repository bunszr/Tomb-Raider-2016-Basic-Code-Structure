using UnityEngine;

public class FrameRateSetter : MonoBehaviour
{
    [Range(0, 120)] public int targetFrameRate = 60;

    private void Update()
    {
        Application.targetFrameRate = targetFrameRate;
    }
}
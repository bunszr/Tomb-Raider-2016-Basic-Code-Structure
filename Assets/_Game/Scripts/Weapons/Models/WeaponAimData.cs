using Cinemachine;
using UnityEngine;

public class WeaponAimData : MonoBehaviour
{
    public Transform aimCamFollowTarget;
    public CinemachineVirtualCamera aimVCamera;
    public CinemachineFreeLook freeLookCam;
    public Canvas aimIndicatorCanvas;
    public Transform aimTargetTransform;
    public Transform strafeDirectionTransform;
}
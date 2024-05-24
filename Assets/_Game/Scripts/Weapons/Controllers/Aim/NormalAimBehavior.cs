using Cinemachine;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class NormalAimBehavior : AimBehaviourBase, IEquiptable
{
    [System.Serializable]
    public class NormalAimBehaviorData
    {
        public Rig[] rigs;
        public float aimTargetPosSmoothTime = .1f;
    }

    Vector3 aimTargetPosCurrVel;

    float weights;
    float Weights
    {
        get => weights;
        set
        {
            for (int i = 0; i < data.rigs.Length; i++) data.rigs[i].weight = value;
            weights = Mathf.Clamp01(value);
        }
    }

    bool enter;
    bool aim;
    Camera cam;

    NormalAimBehaviorData data;
    WeaponAimData weaponAimData;
    IAnimator _animator;
    IThirdPersonController _thirdPersonController;

    GameDataScriptable.WeaponScriptableData.AimData ScriptableData => GameDataScriptable.Ins.weaponScriptableData.aimData;

    public NormalAimBehavior(WeaponBase weaponBase, IAnimator _animator, NormalAimBehaviorData data, WeaponAimData weaponAimData) : base(weaponBase)
    {
        this.data = data;
        this.weaponAimData = weaponAimData;
        cam = Camera.main;
        this._thirdPersonController = _animator as IThirdPersonController;
    }

    public override void Enter()
    {
        base.Enter();
        aim = false;
        enter = true;
    }

    void PressedMethod()
    {
        aim = true;
        weaponAimData.aimVCamera.gameObject.SetActive(true);
        _thirdPersonController.Animator.SetBool(APs.Aim, true);
        _thirdPersonController.IsStrafe = true;
        weaponAimData.aimIndicatorCanvas.gameObject.SetActive(true);
        Vector3 strafeLook = (_thirdPersonController.Transform.position - weaponAimData.freeLookCam.transform.position).SetPosY(0);
        _thirdPersonController.StrafeDirectionTransform.rotation = Quaternion.LookRotation(strafeLook);
        _thirdPersonController.Transform.rotation = Quaternion.LookRotation(strafeLook);
        weaponAimData.aimCamFollowTarget.rotation = Quaternion.LookRotation(strafeLook);
    }

    void ReleasedMethod()
    {
        aim = false;
        weaponAimData.aimVCamera.gameObject.SetActive(false);
        _thirdPersonController.Animator.SetBool(APs.Aim, false);
        _thirdPersonController.IsStrafe = false;
        weaponAimData.aimIndicatorCanvas.gameObject.SetActive(false);
    }

    public override void OnUpdate()
    {
        // Check if it is already pressed "HasPressedAimKey" when weapon toggling process
        if (IM.Ins.Input.WeaponInput.HasHoldingAimKey && enter)
        {
            aim = true;
        }
        else if (IM.Ins.Input.WeaponInput.HasPressedAimKey) PressedMethod();

        if (IM.Ins.Input.WeaponInput.HasReleasedAimKey) ReleasedMethod();

        if (aim)
        {
            Quaternion rotX = Quaternion.AngleAxis(IM.Ins.Input.WeaponInput.HorizontalMouseAxis * Time.deltaTime * ScriptableData.mouseSensitive, Vector3.up);
            Quaternion rotY = Quaternion.AngleAxis(-IM.Ins.Input.WeaponInput.VerticalMouseAxis * Time.deltaTime * ScriptableData.mouseSensitive, Vector3.right);
            weaponAimData.strafeDirectionTransform.rotation *= rotX;
            weaponAimData.aimCamFollowTarget.rotation *= rotY;

            weaponAimData.freeLookCam.m_XAxis.Value = _thirdPersonController.Transform.rotation.eulerAngles.y;

            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width * .5f, Screen.height * .5f));
            Physics.Raycast(ray, out hit, ScriptableData.rayMaxDistance, ScriptableData.layerMask);

            Vector3 targetAimPos;
            if (hit.collider != null) targetAimPos = hit.point;
            else targetAimPos = cam.transform.position + cam.transform.forward * ScriptableData.depth;

            weaponAimData.aimTargetTransform.position = Vector3.SmoothDamp(weaponAimData.aimTargetTransform.position, targetAimPos, ref aimTargetPosCurrVel, data.aimTargetPosSmoothTime);
        }

        Weights += aim ? Time.deltaTime / ScriptableData.rigWeightDuration : -1f * Time.deltaTime / ScriptableData.rigWeightDuration;

        enter = false;
    }
}
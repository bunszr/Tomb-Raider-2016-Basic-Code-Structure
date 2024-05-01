using Cinemachine;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class NormalAimBehavior : AimBehaviourBase, IEquiptable
{
    [System.Serializable]
    public class NormalAimBehaviorData
    {
        public Rig[] rigs;
    }

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
    LivingEntity livingEntity;
    NormalAimBehaviorData data;
    WeaponAimData weaponAimData;
    IWeaponInput _weaponInput;

    GameDataScriptable.WeaponScriptableData.AimData ScriptableData => GameDataScriptable.Ins.weaponScriptableData.aimData;

    public NormalAimBehavior(WeaponBase weaponBase, IWeaponInput weaponInput, LivingEntity livingEntity, NormalAimBehaviorData data, WeaponAimData weaponAimData) : base(weaponBase)
    {
        this.livingEntity = livingEntity;
        this._weaponInput = weaponInput;
        this.data = data;
        this.weaponAimData = weaponAimData;
        cam = Camera.main;
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
        livingEntity.Animator.SetBool(APs.Aim, true);
        livingEntity.ThirdPersonController.ToggleStrafe(true);
        weaponAimData.aimIndicatorCanvas.gameObject.SetActive(true);
    }

    void ReleasedMethod()
    {
        aim = false;
        weaponAimData.aimVCamera.gameObject.SetActive(false);
        livingEntity.Animator.SetBool(APs.Aim, false);
        livingEntity.ThirdPersonController.ToggleStrafe(false);
        weaponAimData.aimIndicatorCanvas.gameObject.SetActive(false);
    }

    public override void OnUpdate()
    {
        // Check if it is already pressed "HasPressedAimKey" when weapon toggling process
        if (_weaponInput.HasHoldingAimKey && enter) PressedMethod();
        else if (_weaponInput.HasPressedAimKey) PressedMethod();

        if (_weaponInput.HasReleasedAimKey) ReleasedMethod();

        if (aim)
        {
            Quaternion rotX = Quaternion.AngleAxis(_weaponInput.HorizontalMouseAxis * Time.deltaTime * ScriptableData.mouseSensitive, Vector3.up);
            Quaternion rotY = Quaternion.AngleAxis(-_weaponInput.VerticalMouseAxis * Time.deltaTime * ScriptableData.mouseSensitive, Vector3.right);
            weaponAimData.strafeDirectionTransform.rotation *= rotX;
            weaponAimData.aimCamFollowTarget.rotation *= rotY;

            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width * .5f, Screen.height * .5f));
            Physics.Raycast(ray, out hit, ScriptableData.rayMaxDistance, ScriptableData.layerMask);

            if (hit.collider != null) weaponAimData.aimTargetTransform.position = hit.point;
            else weaponAimData.aimTargetTransform.position = cam.transform.position + cam.transform.forward * ScriptableData.depth;
        }

        Weights += aim ? Time.deltaTime / ScriptableData.rigWeightDuration : -1f * Time.deltaTime / ScriptableData.rigWeightDuration;

        enter = false;
    }
}
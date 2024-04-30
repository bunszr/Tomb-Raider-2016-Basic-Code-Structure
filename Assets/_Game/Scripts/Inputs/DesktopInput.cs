using UnityEngine;

public partial class DesktopInput : IInput
{
    public IWeaponToggleInput WeaponToggleInput { get; set; }
    public IWeaponInput WeaponInput { get; set; }
    public IAreaInput AreaInput { get; set; }

    public DesktopInput()
    {
        WeaponToggleInput = new WeaponToggleInputDesktop();
        WeaponInput = new WeaponInputDesktop();
        AreaInput = new AreaInputDesktop();
    }

    public class WeaponToggleInputDesktop : IWeaponToggleInput
    {
        public bool HasEquipHand => Input.GetKeyDown(KeyCode.Q);
        public bool HasEquipGun1 => Input.GetKeyDown(KeyCode.Alpha1);
        public bool HasEquipGun2 => Input.GetKeyDown(KeyCode.Alpha2);
        public bool HasEquipGun3 => Input.GetKeyDown(KeyCode.Alpha3);
        public bool HasEquipGun4 => Input.GetKeyDown(KeyCode.Alpha4);
    }

    public class WeaponInputDesktop : IWeaponInput
    {
        public bool HasPressedReloadKey => Input.GetKeyDown(KeyCode.R);
        public bool HasPressedFireKey => Input.GetMouseButtonDown(0);
        public bool HasHoldingFireKey => Input.GetMouseButton(0);
        public bool HasPressedAimKey => Input.GetMouseButtonDown(1);
        public bool HasReleasedAimKey => Input.GetMouseButtonUp(1);
        public bool HasHoldingAimKey => Input.GetMouseButton(1);
        public float HorizontalMouseAxis => Input.GetAxis("Mouse X");
        public float VerticalMouseAxis => Input.GetAxis("Mouse Y");
    }

    public class AreaInputDesktop : IAreaInput
    {
        public bool HasPressedCollectItemKey => Input.GetKeyDown(KeyCode.E);
        public bool HasPressedHitKey => Input.GetKeyDown(KeyCode.E);
    }
}
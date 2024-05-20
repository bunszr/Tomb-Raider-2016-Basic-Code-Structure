using UnityEngine;

public class DesktopInput : IInput
{
    public IWeaponToggleInput WeaponToggleInput { get; set; }
    public IWeaponInput WeaponInput { get; set; }
    public IAreaInput AreaInput { get; set; }
    public IPlayerInput PlayerInput { get; private set; }

    public bool ClosePanelPressKey => Input.GetKeyDown(KeyCode.Escape);


    public DesktopInput()
    {
        WeaponToggleInput = new WeaponToggleInputDesktop();
        WeaponInput = new WeaponInputDesktop();
        AreaInput = new AreaInputDesktop();
        PlayerInput = new PlayerInputDesktop();
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
        public bool HasPressFlashLightKey => Input.GetKeyDown(KeyCode.E);
        public float HorizontalMouseAxis => Input.GetAxis("Mouse X");
        public float VerticalMouseAxis => Input.GetAxis("Mouse Y");
    }

    public class AreaInputDesktop : IAreaInput
    {
        public bool HasPressedCollectItemKey => Input.GetKeyDown(KeyCode.E);
        public bool HasPressedHitKey => Input.GetKeyDown(KeyCode.E);
        public bool HasPressedSitCampsiteKey => Input.GetKeyDown(KeyCode.E);
    }

    public class PlayerInputDesktop : IPlayerInput
    {
        public bool HasPressedJumpInput => Input.GetKeyDown(KeyCode.Space);
        public float HorizontalInput => Input.GetAxis("Horizontal");
        public float VerticalInput => Input.GetAxis("Vertical");
    }

    public class NonePlayerInputDesktop : IPlayerInput
    {
        public bool HasPressedJumpInput => false;
        public float HorizontalInput => 0;
        public float VerticalInput => 0;
    }

    public void ChangePlayerInput(PlayerInputType playerInputType)
    {
        switch (playerInputType)
        {
            case PlayerInputType.None: PlayerInput = new NonePlayerInputDesktop(); break;
            case PlayerInputType.Normal: PlayerInput = new PlayerInputDesktop(); break;
        }
    }
}
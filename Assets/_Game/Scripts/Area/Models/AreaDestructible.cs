using Cinemachine;
using TMPro;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaDestructible : AreaBase, ITriggerablePopUp, INotAllowedTriggerable, IAreaCamera, IPlayerLocation
    {
        public TextMeshProUGUI areaNameText;
        public GameObject punchPopUpGo;
        public GameObject popUpGo;
        public GameObject notAllowedGo;
        public Transform playerLocation;
        public Transform fragmentsHolder;
        public CinemachineVirtualCamera cam;
        public int maxPunchCount = 3;

        public string punchWallIdleAnim;

        public GameObject PopUpGo => popUpGo;
        public bool HasPopUp => true;

        public CinemachineVirtualCamera VirtualCamera => cam;

        public Transform PlayerLocation => playerLocation;

        public GameObject NotAllowedGo => notAllowedGo;
        public bool NotAllowedCondition => false; // Gain digging tool
    }
}
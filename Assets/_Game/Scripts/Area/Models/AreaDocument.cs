using Cinemachine;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TriggerableAreaNamespace
{
    public class AreaDocument : AreaBase, ITriggerablePopUp, INotAllowedTriggerable, IAreaCamera
    {
        public TextMeshProUGUI areaNameText;
        public GameObject popUpGo;
        public GameObject notAllowedGo;
        public CinemachineVirtualCamera cam;

        public GameObject PopUpGo => popUpGo;
        public bool HasPopUp => true;

        public GameObject NotAllowedGo => notAllowedGo;
        public bool NotAllowedCondition => false;

        public CinemachineVirtualCamera VirtualCamera => cam;
    }
}
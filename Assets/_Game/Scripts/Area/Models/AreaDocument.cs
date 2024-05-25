using Cinemachine;
using TMPro;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaDocument : AreaBase, ITriggerablePopUp, INotAllowedTriggerable, IAreaCamera
    {
        public TextMeshProUGUI areaNameText;
        public GameObject popUpGo;
        public GameObject notAllowedGo;
        public CinemachineVirtualCamera cam;
        public CameraFieldOfViewCommand.CameraFieldOfViewCommandData cameraFieldOfViewCommandData;
        public CrossFadeAnimAndWaitUntilFinishCommand.CrossFadeAnimAndWaitUntilFinishCommandData investigateDocumentCommandData;

        public GameObject PopUpGo => popUpGo;
        public bool HasPopUp => true;

        public GameObject NotAllowedGo => notAllowedGo;
        public bool NotAllowedCondition => false;

        public CinemachineVirtualCamera VirtualCamera => cam;
    }
}
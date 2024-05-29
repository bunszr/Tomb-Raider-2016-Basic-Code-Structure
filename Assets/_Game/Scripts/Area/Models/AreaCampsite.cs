using TMPro;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaCampsite : AreaBase, ITriggerablePopUp, INotAllowedTriggerable
    {
        public TextMeshProUGUI areaNameText;
        public GameObject popUpGo;
        public GameObject notAllowedGo;
        public GameObject campsiteFirstPanelToOpenGo;

        public GameObject PopUpGo => popUpGo;
        public GameObject NotAllowedGo => notAllowedGo;
    }
}
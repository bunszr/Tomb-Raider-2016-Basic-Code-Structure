using UnityEngine.EventSystems;
using System;

namespace CampSite
{
    public class ButtonEvents
    {
        public Action<PointerEventData> onPointerEnterEvent;
        public Action<PointerEventData> onPointerExitEvent;
        public Action<PointerEventData> onPointerClickEvent;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace CampSite
{
    public abstract class CSBBaseController : MonoBehaviour, IPanelObserver, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        protected CSBBase csbBase;
        protected List<ICSBActivateable> csbActivateableList = new List<ICSBActivateable>();

        [Inject] protected CinemachineBrain brain;
        [Inject] protected CampSiteHolder campSiteHolder;
        [Inject] protected Player player;

#if UNITY_EDITOR
        [ReadOnly, ShowInInspector] string[] commands => csbActivateableList.Select(x => x.GetType().Name).ToArray();
#endif

        protected virtual void Awake()
        {
            csbBase = GetComponent<CSBBase>();
            GetComponentInParent<ISubject<IPanelObserver>>().Register(this);
        }

        protected virtual void OnDestroy() => GetComponentInParent<ISubject<IPanelObserver>>(true).Unregister(this);

        public void AddCommand(ICSBActivateable _csbActivateable)
        {
            csbActivateableList.Add(_csbActivateable);
        }

        public void RemoveCommand(Func<ICSBActivateable, bool> predicate)
        {
            csbActivateableList.Remove(csbActivateableList.FirstOrDefault(predicate));
        }

        public virtual void OnPanelActive() => csbActivateableList.ForEach(x => x.OnActivate());
        public virtual void OnPanelDeactive() => csbActivateableList.ForEach(x => x.OnDeactivate());

        public virtual void OnPointerEnter(PointerEventData eventData) => csbBase.buttonEvents.onPointerEnterEvent?.Invoke(eventData);
        public virtual void OnPointerExit(PointerEventData eventData) => csbBase.buttonEvents.onPointerExitEvent?.Invoke(eventData);
        public virtual void OnPointerClick(PointerEventData eventData) => csbBase.buttonEvents.onPointerClickEvent?.Invoke(eventData);
    }
}
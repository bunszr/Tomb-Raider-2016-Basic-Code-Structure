using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CampSite
{
    public abstract class CSBBaseController : MonoBehaviour, IPanelObserver
    {
        protected CampSiteButtonBase csbBase;
        protected List<ICSBActivateable> csbActivateableList = new List<ICSBActivateable>();

        [Inject] protected CinemachineBrain brain;
        [Inject] protected CampSiteHolder campSiteHolder;

#if UNITY_EDITOR
        [ReadOnly, ShowInInspector] string[] commands => csbActivateableList.Select(x => x.GetType().Name).ToArray();
#endif

        protected virtual void Awake()
        {
            csbBase = GetComponent<CampSiteButtonBase>();
            GetComponentInParent<ISubject<IPanelObserver>>().Register(this);
        }

        protected virtual void OnDestroy() => GetComponentInParent<ISubject<IPanelObserver>>(true).Unregister(this);

        public void AddCommand(ICSBActivateable _csbActivateable)
        {
            csbActivateableList.Add(_csbActivateable);
        }

        public virtual void OnPanelActive() => csbActivateableList.ForEach(x => x.OnActivate());
        public virtual void OnPanelDeactive() => csbActivateableList.ForEach(x => x.OnDeactivate());
    }
}
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CampSite
{
    public abstract class CSBBaseController : MonoBehaviour
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
        }

        protected virtual void Start() { }
        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }

        public void AddCommand(ICSBActivateable _csbActivateable)
        {
            csbActivateableList.Add(_csbActivateable);
        }
    }
}
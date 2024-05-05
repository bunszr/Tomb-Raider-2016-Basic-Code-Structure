using System.Collections.Generic;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CampSite
{
    public abstract class CSBBaseController : MonoBehaviour
    {
        protected CampSiteButtonBase csbBase;
        [ReadOnly, ShowInInspector] protected List<ICSBActivateable> cSBEnterExits = new List<ICSBActivateable>();

        [Inject] protected CinemachineBrain brain;
        [Inject] protected CampSiteHolder campSiteHolder;

        protected virtual void Awake()
        {
            csbBase = GetComponent<CampSiteButtonBase>();
        }

        protected virtual void Start() { }
        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }
    }
}
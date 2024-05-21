using UnityEngine;
using DG.Tweening;
using System.Collections;
using Zenject;

namespace CampSite
{
    public class CSUpgradedPanelController : MonoBehaviour, IPanelObserver
    {
        [SerializeField] CSUpgradedPanel upgradedPanel;
        [Inject] CampSiteHolder campSiteHolder;
        IPanelToggler _panelToggler;

        GameDataScriptable.CampSiteScriptableData.ShowUpgradedFeatureStateScriptableData Data => GameDataScriptable.Ins.campSiteScriptableData.showUpgradedFeatureStateScriptableData;

        private void Start()
        {
            _panelToggler = GetComponent<IPanelToggler>();
            GetComponentInParent<ISubject<IPanelObserver>>().Register(this);
        }

        private void OnDestroy() => GetComponentInParent<ISubject<IPanelObserver>>(true).Unregister(this);

        public void OnPanelActive()
        {
            StartCoroutine(OnPanelActiveIE());
        }

        public void OnPanelDeactive() { }

        IEnumerator OnPanelActiveIE()
        {
            yield return null; // Wait for FeatureTypeScriptable to not be null

            upgradedPanel.nameText.text = upgradedPanel.FeatureTypeScriptable.FeatureName;
            upgradedPanel.descriptionText.text = upgradedPanel.FeatureTypeScriptable.Description;

            DOTween.Sequence()
            .Append(upgradedPanel.panelGO.transform.DOLocalMoveY(Data.yAnimationAmount, Data.yAnimationDuration).SetEase(Data.yAnimEase).From(true))
            .AppendInterval(Data.waitDuration)
            .OnComplete(() =>
            {
                _panelToggler.Deactive();
                campSiteHolder.CSUndoCommandExecuter.Undo();
            });
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace CampSite
{
    public class RequirementsStateController : ICSBActivateable
    {
        CompositeDisposable disposables = new CompositeDisposable();

        FeatureTypeScriptable featureTypeScriptable;
        ICSBActivateable _showAndHighlightRequirementsState;

        public RequirementsStateController(FeatureTypeScriptable featureTypeScriptable, ICSBActivateable _showAndHighlightRequirementsState)
        {
            this.featureTypeScriptable = featureTypeScriptable;
            this._showAndHighlightRequirementsState = _showAndHighlightRequirementsState;
        }

        void OnRequiringFeatureChange(bool isOpen)
        {
            bool areRequirementsDone = featureTypeScriptable.AreRequirementsDone();
            if (areRequirementsDone)
            {
                _showAndHighlightRequirementsState.OnDeactivate();
                disposables.Dispose();
            }
        }

        public void OnActivate()
        {
            if (!featureTypeScriptable.IsOpenRP.Value && !featureTypeScriptable.AreRequirementsDone())
            {
                _showAndHighlightRequirementsState.OnActivate();

                // It might be opened some requirements when upgrade some feature. We must listen our requiring feature
                foreach (var featureType in GetRequringFeatureTypes())
                {
                    featureType.IsOpenRP.Subscribe(OnRequiringFeatureChange).AddTo(disposables);
                }
            }
        }

        public void OnDeactivate()
        {
            if (!featureTypeScriptable.IsOpenRP.Value && !featureTypeScriptable.AreRequirementsDone())
            {
                _showAndHighlightRequirementsState.OnDeactivate();
                disposables.Clear();
            }
        }

        IEnumerable<FeatureTypeScriptable> GetRequringFeatureTypes() => featureTypeScriptable.RequirementsScriptableBases
            .Where(x => x is FeatureRequirements)
            .Select(x => x as FeatureRequirements)
            .SelectMany(x => x.requireFeatureTypeScriptables);
    }
}
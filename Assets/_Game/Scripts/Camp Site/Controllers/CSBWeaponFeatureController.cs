using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class CSBWeaponFeatureController : CSBBaseController, IPointerClickHandler, IPanelObserver
    {
        CSBWeaponFeature csbWeaponFeature;
        FeatureTypeScriptable featureTypeScriptable;
        WeaponFeatureTypeScriptable weaponFeatureTypeScriptable;

        GameObject nextPanelTogglerGO => campSiteHolder.UpgradedPanel.gameObject;

        ICSBExecute[] _csbExecuteableArray;

        protected override void Start()
        {
            base.Start();

            csbWeaponFeature = csbBase.GetComponent<CSBWeaponFeature>();

            featureTypeScriptable = csbWeaponFeature.FeatureTypeScriptable;
            weaponFeatureTypeScriptable = (WeaponFeatureTypeScriptable)csbWeaponFeature.FeatureTypeScriptable;

            AddCommand(new HighlightCommandView(csbBase, csbWeaponFeature.highlightImage));
            AddCommand(new ShowWeaponDataState(csbBase, csbWeaponFeature.weaponDataScriptable, campSiteHolder.WeaponDataSliderHolder));
            AddCommand(new ShowInformationState(csbBase, campSiteHolder.FeatureInformationPanelHolder, featureTypeScriptable));
            AddCommand(new WeaponRotationState(csbBase, csbWeaponFeature.weaponRotationStateData, campSiteHolder));

            RequirementsStateController requirementsStateController = new RequirementsStateController(featureTypeScriptable,

                new ShowAndHighlightRequirementsState(csbBase, campSiteHolder.FeatureInformationPanelHolder.requirementsText, featureTypeScriptable, csbWeaponFeature.lockImage));

            CostDataCommandController costDataCommandController = new CostDataCommandController(featureTypeScriptable,

                new ShowCostDataState(csbBase, campSiteHolder.CostAndInventoryPanel, weaponFeatureTypeScriptable),
                new ShowOnlyCostDataState(csbBase, campSiteHolder.CostAndInventoryPanel));

            UpgradedTickCommandController upgradedTickCommandController = new UpgradedTickCommandController(featureTypeScriptable,

                new ShowTickImageCommand(csbBase, csbWeaponFeature.upgradedIndicatorImage.gameObject));

            AddCommand(requirementsStateController);
            AddCommand(costDataCommandController);
            AddCommand(upgradedTickCommandController);

            _csbExecuteableArray = new ICSBExecute[]
            {
                new OpenNewPanelCommand(csbBase, nextPanelTogglerGO),
                new BuyInventoryItemCommand(weaponFeatureTypeScriptable),
                new UpgradeWeaponCommonDataState(csbWeaponFeature.weaponDataScriptable, weaponFeatureTypeScriptable),
                new UpgradedPanelDataSetterCommand(nextPanelTogglerGO, featureTypeScriptable),
                new SetFeatureTypeBoolToTrue(featureTypeScriptable),
            };

            GetComponentInParent<ISubject<IPanelObserver>>().Register(this);
        }

        private void OnDestroy() => GetComponentInParent<ISubject<IPanelObserver>>(true).Unregister(this);

        [Button]
        bool IsUpgrade()
        {
            return !csbWeaponFeature.FeatureTypeScriptable.IsOpenRP.Value && weaponFeatureTypeScriptable.HasEnoughQuantityToBuy() && csbBase.FeatureTypeScriptable.AreRequirementsDone();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (IsUpgrade()) _csbExecuteableArray.Foreach(x => x.Execute());
        }

        public void OnPanelActive()
        {
            csbActivateableList.ForEach(x => x.OnActivate());
        }

        public void OnPanelDeactive()
        {
            csbActivateableList.ForEach(x => x.OnDeactivate());
        }
    }
}














// using FSM;
// using UniRx;
// using System.Collections.Generic;
// using System.Linq;
// using Sirenix.OdinInspector;
// using UnityEngine;

// namespace CampSite
// {
//     public class CSBWeaponFeatureController : CSBBaseController
//     {
//         CSBWeaponFeature csbWeaponFeature;
//         CompositeDisposable disposablesForOnRequiringFeatureChange = new CompositeDisposable();
//         FeatureTypeScriptable featureTypeScriptable;
//         WeaponFeatureTypeScriptable weaponFeatureTypeScriptable;

//         GameObject nextPanelTogglerGO => campSiteHolder.UpgradedPanel.gameObject;

//         protected override void Start()
//         {
//             base.Start();


//             csbWeaponFeature = csbBase.GetComponent<CSBWeaponFeature>();

//             featureTypeScriptable = csbWeaponFeature.FeatureTypeScriptable;
//             weaponFeatureTypeScriptable = (WeaponFeatureTypeScriptable)csbWeaponFeature.FeatureTypeScriptable;

//             AddCommand(new HighlighCommand(csbBase, csbWeaponFeature.highlightImage));
//             AddCommand(new ShowWeaponDataState(csbBase, csbWeaponFeature.weaponDataScriptable, campSiteHolder.WeaponDataSliderHolder));
//             AddCommand(new ShowInformationState(csbBase, campSiteHolder.FeatureInformationPanelHolder, csbWeaponFeature.FeatureTypeScriptable));
//             AddCommand(new WeaponRotationState(csbBase, csbWeaponFeature.weaponRotationStateData, campSiteHolder));

//             if (!featureTypeScriptable.IsOpenRP.Value)
//             {
//                 if (!featureTypeScriptable.AreRequirementsDone())
//                 {
//                     AddCommand(new ShowAndHighlightRequirementsState(csbBase, campSiteHolder.FeatureInformationPanelHolder.requirementsText, featureTypeScriptable, csbWeaponFeature.lockImage));
//                 }
//                 AddCommand(new ShowCostDataState(csbBase, campSiteHolder.CostAndInventoryPanel, weaponFeatureTypeScriptable));

//             }
//             else AddCommand(new ShowOnlyCostDataState(csbBase, campSiteHolder.CostAndInventoryPanel));

//             if (IsUpgrade())
//             {
//                 // AddCommand(new OpenNewPanelCommand(csbBase, nextPanelTogglerGO));
//                 // AddCommand(new BuyInventoryItemState(csbBase, weaponFeatureTypeScriptable));
//                 // AddCommand(new UpgradeWeaponCommonDataState(csbBase, csbWeaponFeature.weaponDataScriptable, weaponFeatureTypeScriptable));
//                 // AddCommand(new UpgradedPanelDataSetterCommand(csbBase, nextPanelTogglerGO, featureTypeScriptable));
//                 // AddCommand(new SetFeatureTypeBoolToTrue(csbBase, featureTypeScriptable));
//             }

//             ICSBExecute[] _csbExecuteableArray = new ICSBExecute[]
//             {
//                 new OpenNewPanelCommand(csbBase, nextPanelTogglerGO),
//                 new BuyInventoryItemState(weaponFeatureTypeScriptable),
//                 new UpgradeWeaponCommonDataState(csbWeaponFeature.weaponDataScriptable, weaponFeatureTypeScriptable),
//                 new UpgradedPanelDataSetterCommand(nextPanelTogglerGO, featureTypeScriptable),
//                 new SetFeatureTypeBoolToTrue(featureTypeScriptable),
//             };

//             foreach (var featureType in GetRequringFeatureTypes())
//                 featureType.IsOpenRP.Subscribe(OnRequiringFeatureTypeChange).AddTo(disposablesForOnRequiringFeatureChange);

//             csbActivateableList.ForEach(x => x.OnActivate());

//             featureTypeScriptable.IsOpenRP.Subscribe(OnIsOpenRPChange).AddTo(disposablesForOnRequiringFeatureChange);


//             StateMachine fsm = new StateMachine();
//             fsm.AddState("Click", new State((x) => _csbExecuteableArray.Foreach(x => x.Execute())));
//             fsm.AddTriggerTransitionFromAny("OnClick", new Transition("", "Click", x => IsUpgrade()));
//         }

//         void OnIsOpenRPChange(bool isOpen)
//         {
//             if (isOpen)
//             {

//             }
//             else
//             {

//             }
//         }

//         private void OnDestroy() => disposablesForOnRequiringFeatureChange.Clear();

//         [Button]
//         bool IsUpgrade()
//         {
//             return !csbWeaponFeature.FeatureTypeScriptable.IsOpenRP.Value && weaponFeatureTypeScriptable.HasEnoughQuantityToBuy() && csbBase.FeatureTypeScriptable.AreRequirementsDone();
//         }

//         void OnRequiringFeatureTypeChange(bool isOpen)
//         {
//             if (IsUpgrade())
//             {
//                 Debug.Log("opened", csbBase);
//                 AddCommand(new UpgradedPanelDataSetterCommand(csbBase, nextPanelTogglerGO, featureTypeScriptable));
//                 AddCommand(new OpenNewPanelCommand(csbBase, nextPanelTogglerGO));
//                 AddCommand(new BuyInventoryItemState(csbBase, weaponFeatureTypeScriptable));
//                 AddCommand(new UpgradeWeaponCommonDataState(csbBase, csbWeaponFeature.weaponDataScriptable, weaponFeatureTypeScriptable));
//                 AddCommand(new SetFeatureTypeBoolToTrue(csbBase, featureTypeScriptable));
//             }
//         }

//         IEnumerable<FeatureTypeScriptable> GetRequringFeatureTypes() => csbBase.FeatureTypeScriptable.RequirementsScriptableBases
//             .Where(x => x is FeatureRequirements)
//             .Select(x => x as FeatureRequirements)
//             .SelectMany(x => x.requireFeatureTypeScriptables);
//     }
// }












// using FSM;
// using UniRx;
// using System.Collections.Generic;
// using System.Linq;
// using Sirenix.OdinInspector;
// using UnityEngine;

// namespace CampSite
// {
//     public class CSBWeaponFeatureController : CSBBaseFSM
//     {
//         CSBWeaponFeature cSBWeaponFeature;

//         protected override void Start()
//         {
//             base.Start();

//             cSBWeaponFeature = GetComponent<CSBWeaponFeature>();

//             bool useless = true;
//             List<StateBase> stateBases = new List<StateBase>()
//             {
//                 new HighlightState(csbBase, cSBWeaponFeature.imageToHighlight),
//                 new ShowWeaponDataState(csbBase, cSBWeaponFeature.weaponDataScriptable),
//                 new ShowInformationState(csbBase, useless, cSBWeaponFeature.showInformationState),
//                 new WeaponRotationState(csbBase, useless, cSBWeaponFeature.weaponRotationStateData),
//             };

//             if (!csbBase.FeatureTypeScriptable.IsOpenRP.Value)
//             {
//                 if (!csbBase.FeatureTypeScriptable.AreRequirementsDone()) stateBases.Add(new RequirementsState(csbBase, campSiteHolder.FeatureInformationPanelHolder.requirementsText));
//                 stateBases.Add(new ShowCostDataState(csbBase));
//             }
//             else stateBases.Add(new ShowOnlyCostDataState(csbBase));

//             StateBase[] stateBasesAfterUpgrading = new StateBase[]
//             {
//                 new HighlightState(csbBase, cSBWeaponFeature.imageToHighlight),
//                 new ShowWeaponDataState(csbBase, cSBWeaponFeature.weaponDataScriptable),
//                 new ShowInformationState(csbBase, useless, cSBWeaponFeature.showInformationState),
//                 new WeaponRotationState(csbBase, useless, cSBWeaponFeature.weaponRotationStateData),
//                 new ShowOnlyCostDataState(csbBase),
//             };

//             StateBase[] paralelUpgradingStates = new StateBase[]
//             {
//                 new UpgradeWeaponCommonDataState(csbBase, cSBWeaponFeature.weaponDataScriptable, false),
//                 new BuyInventoryItemState(csbBase, cSBWeaponFeature.weaponDataScriptable, false),
//             };

//             fsm.AddState("InitState", new InitState(csbBase, true, brain));
//             fsm.AddState("HighlightState", new ParalelState(stateBases.ToArray(), false));
//             fsm.AddState("UpgradeState", new ParalelState(paralelUpgradingStates, false, true));
//             fsm.AddState("ShowUpgradedFeatureState", new ShowUpgradedFeatureState(csbBase, true));
//             fsm.AddState("HighlightStateAfterUpgrading", new ParalelState(stateBasesAfterUpgrading, false));

// #if UNITY_EDITOR
//             fsm.AddTransition(new Transition("HighlightState", "ShowUpgradedFeatureState", x => test, true));
// #endif

//             fsm.AddTransition(new Transition("InitState", "HighlightState"));
//             fsm.AddTriggerTransition("OnClick", new Transition("HighlightState", "UpgradeState", x => IsUpgrade()));
//             fsm.AddTransition(new Transition("UpgradeState", "ShowUpgradedFeatureState"));
//             fsm.AddTransition(new Transition("ShowUpgradedFeatureState", "HighlightStateAfterUpgrading"));

//             fsm.SetStartState("InitState");
//             fsm.Init();
//         }

//         public bool test;

//         [Button]
//         bool IsUpgrade()
//         {
//             return !cSBWeaponFeature.FeatureTypeScriptable.IsOpenRP.Value && (csbBase.FeatureTypeScriptable as WeaponFeatureTypeScriptable).HasEnoughQuantityToBuy() && csbBase.FeatureTypeScriptable.AreRequirementsDone();
//         }
//     }
// }

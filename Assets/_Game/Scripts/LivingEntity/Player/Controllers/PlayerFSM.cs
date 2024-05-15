using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSM;
using Sirenix.OdinInspector;
using UniRx;
using Zenject;

namespace CharacterPlayer
{
    public class PlayerFSM : PlayerBaseFSM
    {
        TriggerCustom triggerCustom;
        CompositeDisposable disposables = new CompositeDisposable();

        protected override void Start()
        {
            base.Start();

            fsm.AddState("PlayerInitState", new PlayerInitState(player));
            fsm.AddState("EmptyState", new State());
            fsm.AddState("DeathState", new PlayerDeathState(player, playerControllerGo, false));

            fsm.AddTransition(new Transition("PlayerInitState", "EmptyState"));
            fsm.AddTriggerTransitionFromAny("OnDeath", new Transition("", "DeathState"));

            fsm.Init();
            fsm.SetStartState("PlayerInitState");

            triggerCustom = player.gameObject.GetOrAddComponent<TriggerCustom>();
            triggerCustom.onTriggerEnterEvent += OnCustomTriggerEnter;
            triggerCustom.onTriggerExitEvent += OnCustomTriggerExit;

            player.HealthRP.Where(x => x <= 0).Subscribe(x => OnPlayerDeath());

            player.FastHealingFeatureScriptable.IsOpenRP.Subscribe(OnFastHealing).AddTo(disposables);
        }

        public void OnFastHealing(bool isOpen)
        {
        }

        private void OnDestroy()
        {
            triggerCustom.onTriggerEnterEvent -= OnCustomTriggerEnter;
            triggerCustom.onTriggerExitEvent -= OnCustomTriggerExit;
            disposables.Dispose();
        }

        void OnPlayerDeath() => fsm.TriggerLocally("OnDeath");

        private void OnCustomTriggerEnter(Collider other) { }
        private void OnCustomTriggerExit(Collider other) { }


#if UNITY_EDITOR
        [Button] void SetHealth(int value = 0) => player.HealthRP.Value = value;
#endif
    }
}
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

        protected override void Start()
        {
            base.Start();

            fsm.AddState("PlayerInitState", new PlayerInitState(player));
            fsm.AddState("EmptyState", new State());
            fsm.AddState("DeathState", new PlayerDeathState(player, false));

            fsm.AddTransition(new Transition("PlayerInitState", "EmptyState"));
            fsm.AddTriggerTransitionFromAny("OnDeath", new Transition("", "DeathState"));

            fsm.Init();
            fsm.SetStartState("PlayerInitState");

            triggerCustom = player.gameObject.GetOrAddComponent<TriggerCustom>();
            triggerCustom.onTriggerEnterEvent += OnCustomTriggerEnter;
            triggerCustom.onTriggerExitEvent += OnCustomTriggerExit;

            player.Health.Where(x => x <= 0).Subscribe(x => OnPlayerDeath());
        }

        private void OnDestroy()
        {
            triggerCustom.onTriggerEnterEvent -= OnCustomTriggerEnter;
            triggerCustom.onTriggerExitEvent -= OnCustomTriggerExit;
        }

        void OnPlayerDeath() => fsm.TriggerLocally("OnDeath");

        private void OnCustomTriggerEnter(Collider other) { }
        private void OnCustomTriggerExit(Collider other) { }


#if UNITY_EDITOR
        [Button] void SetHealth(int value = 0) => player.Health.Value = value;
#endif
    }
}
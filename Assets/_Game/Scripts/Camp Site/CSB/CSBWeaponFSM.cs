// using FSM;

// namespace CampSite
// {
//     public class CSBWeaponFSM : CSBBaseFSM
//     {
//         CSBWeapon cSBWeapon;

//         protected override void Start()
//         {
//             base.Start();

//             cSBWeapon = GetComponent<CSBWeapon>();

//             fsm.AddState("InitState", new InitState(this, true, brain));
//             fsm.AddState("HighlightState", new HighlightState(this, false, cSBWeapon.buttonEvents, cSBWeapon.highlightStateData));
//             fsm.AddState("ClickState", new ClickState(this, false, cSBWeapon.clickStateData));

//             fsm.AddTransition(new Transition("InitState", "HighlightState"));
//             fsm.AddTriggerTransition("OnClick", new Transition("HighlightState", "ClickState"));

//             fsm.SetStartState("InitState");
//             fsm.Init();
//         }
//     }
// }
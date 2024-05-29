namespace TriggerableAreaNamespace
{
    public class AreaCommonPopUpController : AreaBasePopUpController
    {
        AreaPopUpTrigger normalPopUpTrigger;

        protected override void Start()
        {
            base.Start();

            normalPopUpTrigger = new AreaPopUpTrigger(triggerCustom, null,
                new ShowNormalPopUpView(areaBase.GetComponent<ITriggerablePopUp>())
            );

            normalPopUpTrigger.Enter();
        }

        private void OnDestroy()
        {
            normalPopUpTrigger.Exit();
        }
    }
}
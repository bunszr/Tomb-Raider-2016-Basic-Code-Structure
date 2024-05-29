using DG.Tweening;

namespace TriggerableAreaNamespace
{
    public class ShowNotAllowedPopUpView : IEnterExit
    {
        INotAllowedTriggerable _triggerablePopUp;
        public ShowNotAllowedPopUpView(INotAllowedTriggerable triggerablePopUp) => _triggerablePopUp = triggerablePopUp;

        public void Enter()
        {
            _triggerablePopUp.NotAllowedGo.SetActive(true);
            _triggerablePopUp.NotAllowedGo.transform.DOScale(1, .3f).From(0);
        }

        public void Exit()
        {
            _triggerablePopUp.NotAllowedGo.SetActive(false);
            _triggerablePopUp.NotAllowedGo.transform.DOKill();
        }
    }
}
using DG.Tweening;

namespace TriggerableAreaNamespace
{
    public class ShowNormalPopUpView : IEnterExit
    {
        ITriggerablePopUp _triggerablePopUp;

        public ShowNormalPopUpView(ITriggerablePopUp triggerablePopUp) => _triggerablePopUp = triggerablePopUp;

        public void Enter()
        {
            _triggerablePopUp.PopUpGo.SetActive(true);
            _triggerablePopUp.PopUpGo.transform.DOScale(1, .3f).From(0);
        }

        public void Exit()
        {
            _triggerablePopUp.PopUpGo.SetActive(false);
            _triggerablePopUp.PopUpGo.transform.DOKill();
        }
    }
}
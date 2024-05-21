using UnityEngine;
using Zenject;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class CSPanelCloser : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPanelObserver
    {
        [Inject] CampSiteHolder campSiteHolder;
        [SerializeField] Button button;
        IPanelToggler _panelToggler;

        Coroutine coroutine;

        bool mouseIsEnter;

        private void Start()
        {
            _panelToggler = GetComponentInParent<IPanelToggler>();
            GetComponentInParent<ISubject<IPanelObserver>>().Register(this);
        }

        private void OnDestroy() => GetComponentInParent<ISubject<IPanelObserver>>(true).Unregister(this);

        public void OnPanelActive()
        {
            button.onClick.AddListener(OnClick);
            coroutine = StartCoroutine(CheckInput());
        }

        public void OnPanelDeactive()
        {
            button.onClick.RemoveListener(OnClick);
            StopCoroutine(coroutine);
        }

        public void OnClick()
        {
            _panelToggler.Deactive();
            campSiteHolder.CSUndoCommandExecuter.Undo();
        }

        IEnumerator CheckInput()
        {
            yield return null; // Another Panel closer active after this one. It must be waited a frame
            while (true)
            {
                if (IM.Ins.Input.ClosePanelPressKey && !mouseIsEnter) OnClick();
                yield return null;
            }
        }

        public void OnPointerEnter(PointerEventData eventData) => mouseIsEnter = true;
        public void OnPointerExit(PointerEventData eventData) => mouseIsEnter = false;
    }
}
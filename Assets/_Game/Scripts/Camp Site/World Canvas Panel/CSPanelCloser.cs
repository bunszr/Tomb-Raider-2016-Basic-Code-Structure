using UnityEngine;
using Zenject;
using UnityEngine.UI;
using UniRx;
using System.Collections;
using System;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class CSPanelCloser : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] IInput _input;
        [Inject] CampSiteHolder campSiteHolder;
        [SerializeField] Button button;
        IPanelToggler _panelToggler;

        IDisposable disposable;
        Coroutine coroutine;

        bool mouseIsEnter;

        private void Awake()
        {
            button.onClick.AddListener(OnClick);
            _panelToggler = GetComponentInParent<IPanelToggler>();
            disposable = _panelToggler.IsActiveRP.Subscribe(OnIsActiveChange);
        }

        private void OnDestroy() => disposable.Dispose();

        void OnIsActiveChange(bool active)
        {
            if (active) coroutine = StartCoroutine(CheckInput());
            else if (!active && coroutine != null) StopCoroutine(coroutine);
        }

        public void OnClick()
        {
            _panelToggler.Deactive();
            campSiteHolder.CampsiteCommandExecuter.Undo();
        }

        IEnumerator CheckInput()
        {
            yield return null; // Another Panel closer active after this one. It must be waited a frame
            while (true)
            {
                if (_input.ClosePanelPressKey && !mouseIsEnter) OnClick();
                yield return null;
            }
        }

        public void OnPointerEnter(PointerEventData eventData) => mouseIsEnter = true;
        public void OnPointerExit(PointerEventData eventData) => mouseIsEnter = false;
    }
}

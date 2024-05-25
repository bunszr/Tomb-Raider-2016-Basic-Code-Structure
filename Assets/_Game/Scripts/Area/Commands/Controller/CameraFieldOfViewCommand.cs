using DG.Tweening;

namespace TriggerableAreaNamespace
{
    public class CameraFieldOfViewCommand : IAreaCommad
    {
        [System.Serializable]
        public class CameraFieldOfViewCommandData
        {
            public float targetFOV = 30;
            public float duration = 2;
            public Ease ease = Ease.InOutSine;
        }

        CameraFieldOfViewCommandData data;
        IAreaCamera _areaCamera;
        Tween tween;

        public CameraFieldOfViewCommand(IAreaCamera _areaCamera, CameraFieldOfViewCommandData data)
        {
            this._areaCamera = _areaCamera;
            this.data = data;
        }

        public void Enter()
        {
            float val = _areaCamera.VirtualCamera.m_Lens.FieldOfView;
            tween = DOTween.To(() => val, x => val = x, data.targetFOV, data.duration).SetEase(data.ease).SetLoops(2, LoopType.Yoyo).OnUpdate(() =>
            {
                _areaCamera.VirtualCamera.m_Lens.FieldOfView = val;
            });
        }

        public void Exit() => tween.KillMine();
        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}
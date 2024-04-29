using System;
using System.Linq;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class CameraFieldOfViewCommand : IAreaCommad
    {
        IAreaCamera _areaCamera;
        AreaBase areaBase;
        Tween tween;

        public CameraFieldOfViewCommand(AreaBase areaBase)
        {
            this.areaBase = areaBase;
            _areaCamera = areaBase as IAreaCamera;
        }

        public void Enter()
        {
            float val = 40;
            tween = DOTween.To(() => val, x => val = x, 20, 3).SetEase(Ease.InFlash, 2).OnUpdate(() =>
            {
                _areaCamera.VirtualCamera.m_Lens.FieldOfView = val;
            });
        }

        public void Exit() => tween.KillMine();
        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}
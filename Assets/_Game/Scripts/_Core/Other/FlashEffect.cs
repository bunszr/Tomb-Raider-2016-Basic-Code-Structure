using UnityEngine;
using DG.Tweening;

public class FlashEffect : MonoBehaviour
{
    public Color toColor = Color.black;
    public float duration = .3f;

    public static readonly int
       _CurrColor = Shader.PropertyToID("_CurrColor");


    public Renderer render;

    Tween tween;

    private void OnEnable()
    {
        tween = render.material.DOColor(toColor, _CurrColor, duration).SetEase(Ease.Flash, 2).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDisable()
    {
        tween.Kill();
        tween = null;
    }
}
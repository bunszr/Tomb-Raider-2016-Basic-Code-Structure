using System.Collections.Generic;
using DG.Tweening;

public class TweenDisposable
{
    public List<Tween> tweens = new List<Tween>();

    public void KillAllMine()
    {
        tweens.ForEach(x => x.KillMine());
        tweens.Clear();
    }

}
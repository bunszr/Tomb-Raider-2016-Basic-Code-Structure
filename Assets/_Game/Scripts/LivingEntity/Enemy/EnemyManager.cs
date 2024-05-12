using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class EnemyManager : SingletonAndDontDestroyOnLoad<EnemyManager>
{
    [Inject, ReadOnly] public CoverLocationHolder coverLocationHolder;

    public ListMine<Enemy> EnemyListMine { get; private set; } = new ListMine<Enemy>();
}
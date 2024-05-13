using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class EnemyManager : SingletonAndDontDestroyOnLoad<EnemyManager>
{
    [Inject, ReadOnly] public CoverLocationHolder coverLocationHolder;
    [Inject, ReadOnly] public Player player;

    public ListMine<Enemy> EnemyListMine { get; private set; } = new ListMine<Enemy>();
}
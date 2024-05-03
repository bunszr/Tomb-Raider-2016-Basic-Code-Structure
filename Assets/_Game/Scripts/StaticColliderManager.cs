using UnityEngine;
using System.Collections.Generic;
using WeaponNamescape.Enemy;

public static class StaticColliderManager
{
    // You can get via transform instance id

    public static Dictionary<int, Player> PlayerDictionary { get; private set; } = new Dictionary<int, Player>();

    public static Dictionary<int, IEnemyTarget> _EnemyTargetDictionary { get; private set; } = new Dictionary<int, IEnemyTarget>();
    public static List<IEnemyTarget> EnemyTargetList { get; private set; } = new List<IEnemyTarget>();

    public static void AddIEnemyTarget(int transformInsId, IEnemyTarget _enemyTarget)
    {
        EnemyTargetList.Add(_enemyTarget);
        _EnemyTargetDictionary.Add(transformInsId, _enemyTarget);
    }

    public static void RemoveIEnemyTarget(int transformInsId, IEnemyTarget _enemyTarget)
    {
        EnemyTargetList.Remove(_enemyTarget);
        _EnemyTargetDictionary.Remove(transformInsId);
    }
}
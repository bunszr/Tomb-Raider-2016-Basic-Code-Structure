using System.Collections.Generic;

public static class StaticColliderManager
{
    // You can get via transform instance id

    public static Dictionary<int, IGiveDamage> IGiveDamageDictionary { get; private set; } = new Dictionary<int, IGiveDamage>();
}
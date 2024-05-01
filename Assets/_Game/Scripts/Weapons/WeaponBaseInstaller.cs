using UnityEngine;
using System.Collections.Generic;

public abstract class WeaponBaseInstaller : MonoBehaviour
{
    public WeaponBase weaponBase;

    protected List<IEquiptable> _equipableList;
    protected List<IExtraFire> _extraFireList;
}
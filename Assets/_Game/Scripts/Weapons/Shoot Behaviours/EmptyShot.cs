// using UnityEngine;

// public class EmptyShot : ShootBehaviourBase
// {
//     [System.Serializable]
//     public class EmptyShotData
//     {
//         public float unnecessary;
//     }

//     public EmptyShotData data;

//     public EmptyShot(IWeapon _weapon, EmptyShotData data) : base(_weapon)
//     {
//         this.data = data;
//     }

//     public override void OnUpdate()
//     {
//         if (Input.GetMouseButtonDown(0) && _weapon.GetAmmoData().CurrAmmoRP.Value == 0 && _weapon.GetAmmoData().TotalAmmoRP.Value == 0)
//         {
//             Debug.Log("Empty shot");
//         }
//     }
// }
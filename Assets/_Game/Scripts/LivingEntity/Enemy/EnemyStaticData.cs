using UnityEngine;

public static class EnemyStaticData
{
    public static Vector3 RaycastUpVector = Vector3.up * 1.3f;

    public static class BHTKey
    {
        public static readonly string ThirdPersonControllerGo = "ThirdPersonControllerGo";
        public static readonly string NavmeshDestination = "NavmeshDestination";
        public static readonly string CoverLocationDataGo = "CoverLocationDataGo";
        public static readonly string NavmeshDestinationSplineComputerGo = "NavmeshDestinationSplineComputerGo";

        public static readonly string Model = "Model";
        public static readonly string Controller = "Controller";

        public static readonly string MoveToEnemyTargetComputerGo = "MoveToEnemyTargetComputerGo";
    }
}
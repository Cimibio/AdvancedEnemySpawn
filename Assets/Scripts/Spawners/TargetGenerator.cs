using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    [SerializeField] private RoutesGenerator _routesGenerator;
    [SerializeField] private Target _targetPrefab;

    private int _spawnPositionNumber = 0;

    public Target Spawn(Color color)
    {
        Route route = _routesGenerator.Generate();

        if (route.RoutePoints == null || route.RoutePoints.Count == 0)
        {
            Debug.LogError("Generated route has no points!");
            return null;
        }

        Vector3 spawnPosition = route.RoutePoints[_spawnPositionNumber];
        Target target = Instantiate(_targetPrefab);
        target.Init(spawnPosition, route, color);

        return target;
    }
}

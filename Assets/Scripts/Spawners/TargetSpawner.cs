using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private RoutesGenerator _routesGenerator;
    [SerializeField] private SpawnPointGenerator _pointGenerator;
    [SerializeField] private Target _targetPrefab;

    private void Spawn()
    {
        SpawnPoint spawnPoint = _pointGenerator.GetRandomSpawnPoint();
        Color color = spawnPoint.Color;
        Route route = _routesGenerator.GetRoute();
        Vector3 firstRoutePoint = route.RoutePoints[0];
        //Vector3 moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        Target target = Instantiate(_targetPrefab);
        target.Init(firstRoutePoint, route, color);
    }

}

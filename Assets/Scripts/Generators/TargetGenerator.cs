using UnityEngine;
using System.Collections.Generic;

public class TargetGenerator : Generator
{
    [Header("Настройки целей")]
    [SerializeField] private RoutesGenerator _routesGenerator;
    [SerializeField] private Target _targetPrefab;

    private int _spawnPositionNumber = 0;
    private List<Target> _createdTargets = new List<Target>();

    public Target Generate(Color color)
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

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.red;

        foreach (var target in _createdTargets)
        {
            if (target != null)
            {
                Gizmos.DrawSphere(target.transform.position, 0.4f);
            }
        }
    }
}
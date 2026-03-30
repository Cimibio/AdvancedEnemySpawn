using UnityEngine;

public class TargetGenerator : GeneratorBase<Target>
{
    [Header("Настройки целей")]
    [SerializeField] private RoutesGenerator _routesGenerator;
    [SerializeField] private Target _targetPrefab;

    private int _spawnPositionNumber = 0;
    private Color _gizmoColor = Color.red;
    private float _gizmoSize = 0.4f;

    public Target Generate(Color color)
    {
        Target target = Instantiate(_targetPrefab);
        Route route = _routesGenerator.Generate();

        if (route.RoutePoints == null || route.RoutePoints.Count == 0)
        {
            Debug.LogError("Generated route has no points!");
            return null;
        }

        Vector3 spawnPosition = route.RoutePoints[_spawnPositionNumber];
        target.Init(spawnPosition, route, color);

        _createdItems.Add(target);
        return target;
    }

    protected override void DrawItemGizmo(Target target)
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawSphere(target.transform.position, _gizmoSize);
    }
}
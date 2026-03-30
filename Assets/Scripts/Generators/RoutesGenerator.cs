using UnityEngine;

public class RoutesGenerator : GeneratorBase<Route>
{
    [Header("Настройки маршрутов")]
    [SerializeField] private Route _routePrefab;

    private Color _gizmoColor = Color.yellow;
    private float _gizmoSize = 0.3f;

    public Route Generate()
    {
        Route route = Instantiate(_routePrefab);

        int pointsCount = Random.Range(MinCount, MaxCount);

        for (int i = 0; i < pointsCount; i++)
        {
            Vector3 position = CalculateRandomPosition();
            route.Add(position);
        }

        _createdItems.Add(route);
        return route;
    }

    protected override void DrawItemGizmo(Route route)
    {
        Gizmos.color = _gizmoColor;

        if (route != null && route.RoutePoints.Count > 0)
        {
            Vector3 prevPoint = route.RoutePoints[0];

            foreach (var point in route.RoutePoints)
            {
                Gizmos.DrawSphere(point, _gizmoSize);
                Gizmos.DrawLine(prevPoint, point);
                prevPoint = point;
            }
        }
    }
}
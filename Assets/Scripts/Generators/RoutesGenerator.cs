using System.Collections.Generic;
using UnityEngine;

public class RoutesGenerator : Generator
{
    [Header("Настройки маршрутов")]
    [SerializeField] private Route _routePrefab;

    //private int _routeCounter = 0;
    private List<Route> _routes = new List<Route>();

    public Route Generate()
    {
        Route route = Instantiate(_routePrefab);

        int pointsCount = Random.Range(MinCount, MaxCount);

        for (int i = 0; i < pointsCount; i++)
        {
            Vector3 position = CalculateRandomPosition();
            route.Add(position);
        }

        _routes.Add(route);
        return route;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;

        foreach (var route in _routes)
        {
            if (route != null && route.RoutePoints.Count > 0)
            {
                Vector3 prevPoint = route.RoutePoints[0];

                foreach (var point in route.RoutePoints)
                {
                    Gizmos.DrawSphere(point, 0.3f);
                    Gizmos.DrawLine(prevPoint, point);
                    prevPoint = point;
                }
            }
        }
    }
}
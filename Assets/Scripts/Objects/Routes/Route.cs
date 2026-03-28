using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    private List<Vector3> _routesPoints = new List<Vector3>();

    public IReadOnlyList<Vector3> RoutePoints => _routesPoints;

    public void Add(Vector3 routePoint)
    {
        _routesPoints.Add(routePoint);
    }

    public void Remove(int index) 
    {
        _routesPoints.RemoveAt(index); 
    }
}

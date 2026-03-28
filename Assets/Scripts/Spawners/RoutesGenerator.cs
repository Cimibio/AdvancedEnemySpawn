using UnityEngine;

public class RoutesGenerator : MonoBehaviour
{
    [Header("Настройки генерации")]
    [SerializeField][Tooltip("Минимальное количество точек маршрута")] private int _minPoints = 4;
    [SerializeField][Tooltip("Максимальное количество точек маршрута")] private int _maxPoints = 7;
    [SerializeField][Tooltip("Максимальное отклонение по оси X от Генератора")] private float _xOffset = 15;
    [SerializeField][Tooltip("Максимальное отклонение по оси Z от Генератора")] private float _zOffset = 15;
    [SerializeField] private float _yOffset = 1f;

    private int number = 0;

    //private List<Route> _routes = new List<Route>();

    //public IReadOnlyList<Route> Routes => _routes;

    public Route Generate()
    {
        GameObject routeObject = new GameObject($"Route_{number}");
        Route route = routeObject.AddComponent<Route>();

        int count = Random.Range(_minPoints, _maxPoints);

        for (int i = 0; i < count; i++)
        {
            Vector3 position = CalculateRandomPosition();
            route.Add(position);
        }

        number++;

        return route;
    }

    private Vector3 CalculateRandomPosition()
    {
        float x = Random.Range(transform.position.x - _xOffset, transform.position.x + _xOffset);
        float z = Random.Range(transform.position.z - _zOffset, transform.position.z + _zOffset);
        float y = transform.position.y + _yOffset;

        return new Vector3(x, y, z);
    }
}

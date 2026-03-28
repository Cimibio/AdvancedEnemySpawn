using System.Collections.Generic;
using UnityEngine;

public class SpawnPointGenerator : MonoBehaviour
{
    [Header("Настройки генерации")]
    [SerializeField] SpawnPoint _spawnPointPrefab;
    [SerializeField] TargetGenerator _targetGenerator;
    [SerializeField][Tooltip("Минимальное количество точек спавна")] private int _minPoints = 3;
    [SerializeField][Tooltip("Максимальное количество точек спавна")] private int _maxPoints = 5;
    [SerializeField][Tooltip("Максимальное отклонение по оси X от Генератора")] private float _xOffset = 10;
    [SerializeField][Tooltip("Максимальное отклонение по оси Z от Генератора")] private float _zOffset = 10;
    [SerializeField] private float _yOffset = 1f;

    [Header("Визуализация")]
    [SerializeField] private Color _gizmoColor = Color.green;
    [SerializeField] private float _gizmoRadius = 0.5f;

    List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

    private void Awake()
    {
        Generate();
    }

    public SpawnPoint GetRandomSpawnPoint()
    {
        if (_spawnPoints == null || _spawnPoints.Count == 0)
        {
            Debug.LogError("No spawn points available!");
            return null;
        }

        int number = Random.Range(0, _spawnPoints.Count);
        return _spawnPoints[number];
    }

    private void Generate()
    {
        int count = Random.Range(_minPoints, _maxPoints);

        for (int i = 0; i < count; i++)
        {
            SpawnPoint point = Instantiate(_spawnPointPrefab, transform);

            Color color = Random.ColorHSV();
            Vector3 position = CalculateRandomPosition();

            Target target = _targetGenerator.Spawn(color);

            point.Init(position, color, target);

            _spawnPoints.Add(point);
        }
    }

    private Vector3 CalculateRandomPosition()
    {
        float x = Random.Range(transform.position.x - _xOffset, transform.position.x + _xOffset);
        float z = Random.Range(transform.position.z - _zOffset, transform.position.z + _zOffset);
        float y = transform.position.y + _yOffset;

        return new Vector3(x, y, z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;

        foreach (Transform child in transform)
        {
            Gizmos.DrawSphere(child.position, _gizmoRadius);
            Gizmos.DrawLine(transform.position, child.position);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class SpawnPointGenerator : Generator
{
    [Header("Настройки точек спавна")]
    [SerializeField] private SpawnPoint _spawnPointPrefab;
    [SerializeField] private TargetGenerator _targetGenerator;

    private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        int count = GetRandomCount();

        for (int i = 0; i < count; i++)
        {
            CreateSpawnPoint();
        }
    }

    public void CreateSpawnPoint()
    {
        Color color = Random.ColorHSV();
        Vector3 position = CalculateRandomPosition();

        Target target = _targetGenerator.Generate(color);

        SpawnPoint point = Instantiate(_spawnPointPrefab, transform);
        point.Init(position, color, target);

        _spawnPoints.Add(point);
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

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.cyan;

        foreach (var point in _spawnPoints)
        {
            if (point != null)
            {
                Gizmos.DrawSphere(point.GetTransform.position, _gizmoRadius * 0.8f);

                if (point.Target != null)
                {
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawLine(point.GetTransform.position, point.Target.transform.position);
                    Gizmos.color = Color.cyan;
                }
            }
        }
    }
}
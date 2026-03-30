using UnityEngine;

public class SpawnPointGenerator : GeneratorBase<SpawnPoint>
{
    [Header("Настройки точек спавна")]
    [SerializeField] private SpawnPoint _spawnPointPrefab;
    [SerializeField] private TargetGenerator _targetGenerator;

    private Color _gizmoColor = Color.blue;
    private float _gizmoSize = 0.5f;

    private void Awake()
    {
        Generate();
    }

    public SpawnPoint GetRandomSpawnPoint()
    {
        if (_createdItems == null || _createdItems.Count == 0)
        {
            Debug.LogError("No spawn points available!");
            return null;
        }

        int number = Random.Range(0, _createdItems.Count);

        return _createdItems[number];
    }
    protected override void DrawItemGizmo(SpawnPoint spawnPoint)
    {
        Gizmos.color = _gizmoColor;

        if (spawnPoint != null)
        {
            Gizmos.DrawSphere(spawnPoint.transform.position, _gizmoSize);
        }
    }

    private void Generate()
    {
        int count = GetRandomCount();

        for (int i = 0; i < count; i++)
        {
            CreateSpawnPoint();
        }
    }

    private void CreateSpawnPoint()
    {
        SpawnPoint point = Instantiate(_spawnPointPrefab, transform);
        Color color = Random.ColorHSV();
        Vector3 position = CalculateRandomPosition();

        Target target = _targetGenerator.Generate(color);

        point.Init(position, color, target);

        _createdItems.Add(point);
    }
}
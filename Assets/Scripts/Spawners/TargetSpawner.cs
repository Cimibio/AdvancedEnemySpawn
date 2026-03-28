using Spawners;
using UnityEngine;

public class TargetSpawner : Spawner<Target>
{
    [SerializeField] private SpawnPointGenerator _pointGenerator;
    [SerializeField] private Target _targetPrefab;

    private void nEnable()
    {
        _pointGenerator.Created += Spawn;
    }

    protected override void Spawn(Color color)
    {
        Vector3 spawnPoint = _pointGenerator.GetRandomPoint().position;
        Vector3 moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        base.Spawn(target);
        target.Init(spawnPoint, moveDirection);
    }

    private void OnEnemyFall(Target target)
    {
        ReleaseToPool(target);
    }
}

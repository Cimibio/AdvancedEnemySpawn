using Spawners;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private SpawnPointGenerator _pointGenerator;

    protected override void Spawn(Enemy enemy)
    {
        SpawnPoint spawnPoint = _pointGenerator.GetRandomSpawnPoint();
        Vector3 spawnPointPosition = spawnPoint.GetTransform.position;
        Vector3 moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        Color color = spawnPoint.Color;
        Target target = spawnPoint.Target;

        base.Spawn(enemy);
        enemy.Init(spawnPointPosition, moveDirection, color);
        enemy.Falled += OnEnemyFall;
    }

    private void OnEnemyFall(Enemy enemy)
    {
        enemy.Falled -= OnEnemyFall;
        ReleaseToPool(enemy);
    }
}


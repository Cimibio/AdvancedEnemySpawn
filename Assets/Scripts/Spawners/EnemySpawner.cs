using Spawners;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private SpawnPointGenerator _spawnPointGenerator;

    protected override void Spawn(Enemy enemy)
    {
        SpawnPoint spawnPoint = _spawnPointGenerator.GetRandomSpawnPoint();
        Vector3 spawnPointPosition = spawnPoint.GetTransform.position;
        Color color = spawnPoint.Color;
        Target target = spawnPoint.Target;

        base.Spawn(enemy);
        enemy.Init(spawnPointPosition, color, target);

        enemy.Falled += OnEnemyFall;
    }

    private void OnEnemyFall(Enemy enemy)
    {
        enemy.Falled -= OnEnemyFall;
        ReleaseToPool(enemy);
    }
}


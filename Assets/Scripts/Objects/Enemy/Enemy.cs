using System;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(EnemyFallDetector), typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    private Mover _enemyMover;
    private EnemyFallDetector _fallDetector;
    private Renderer _renderer;
    private Target _target;

    public event Action<Enemy> Falled;

    private void Awake()
    {
        _enemyMover = GetComponent<Mover>();
        _fallDetector = GetComponent<EnemyFallDetector>();
        _renderer = GetComponent<Renderer>();
        _fallDetector.OnFall += HandleFall;
    }

    private void Update()
    {
        Vector3 direction;

        if (_target == null)
            direction = _enemyMover.GetRandomDirection();
        else
            direction = (_target.transform.position - transform.position).normalized;

        _enemyMover.SetDirection(direction);
    }

    private void OnDestroy()
    {
        if (_fallDetector != null)
            _fallDetector.OnFall -= HandleFall;
    }

    public void Init(Vector3 position, Color color)
    {
        transform.position = position;
        _renderer.material.color = color;
    }

    public void SetTarget(Target target)
    {
        _target = target;
    }

    private void HandleFall()
    {
        Falled?.Invoke(this);
    }
}
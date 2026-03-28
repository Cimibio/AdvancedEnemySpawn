using System;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(EnemyFallDetector))]
public class Enemy : MonoBehaviour
{
    private Mover _enemyMover;
    private EnemyFallDetector _fallDetector;
    private Color _color;

    public event Action<Enemy> Falled;

    private void Awake()
    {
        _enemyMover = GetComponent<Mover>();
        _fallDetector = GetComponent<EnemyFallDetector>();

        _fallDetector.OnFall += HandleFall;
    }

    private void OnDestroy()
    {
        if (_fallDetector != null)
            _fallDetector.OnFall -= HandleFall;
    }

    public void Init(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        _enemyMover.SetDirection(direction);
    }

    private void HandleFall()
    {
        Falled?.Invoke(this);
    }
}
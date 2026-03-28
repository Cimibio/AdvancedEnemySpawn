using System;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(EnemyFallDetector), typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    private Mover _enemyMover;
    private EnemyFallDetector _fallDetector;
    private Renderer _renderer;
    private string _type;

    public event Action<Enemy> Falled;

    private void Awake()
    {
        _enemyMover = GetComponent<Mover>();
        _fallDetector = GetComponent<EnemyFallDetector>();
        _renderer = GetComponent<Renderer>();
        _fallDetector.OnFall += HandleFall;
    }

    private void OnDestroy()
    {
        if (_fallDetector != null)
            _fallDetector.OnFall -= HandleFall;
    }

    public void Init(Vector3 position, Vector3 direction, Color color)
    {
        transform.position = position;
        _renderer.material.color = color;
        _enemyMover.SetDirection(direction);
    }

    private void HandleFall()
    {
        Falled?.Invoke(this);
    }
}
using UnityEngine;
using System;

public class EnemyFallDetector : MonoBehaviour
{
    [SerializeField] private float _fallThreshold = -1f;

    public event Action Falled;

    private void Update()
    {
        if (transform.position.y < _fallThreshold)
        {
            Falled?.Invoke();
        }
    }
}
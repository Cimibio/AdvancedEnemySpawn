using UnityEngine;

public abstract class Generator : MonoBehaviour
{
    [Header("Основные настройки генерации")]
    [SerializeField] protected int _minCount = 3;
    [SerializeField] protected int _maxCount = 5;
    [SerializeField] protected float _xOffset = 10f;
    [SerializeField] protected float _zOffset = 10f;
    [SerializeField] protected float _yOffset = 1f;

    [Header("Визуализация")]
    [SerializeField] protected Color _gizmoColor = Color.green;
    [SerializeField] protected float _gizmoRadius = 0.5f;

    protected virtual Vector3 CalculateRandomPosition()
    {
        float x = Random.Range(transform.position.x - _xOffset, transform.position.x + _xOffset);
        float z = Random.Range(transform.position.z - _zOffset, transform.position.z + _zOffset);
        float y = transform.position.y + _yOffset;

        return new Vector3(x, y, z);
    }

    protected int GetRandomCount()
    {
        return Random.Range(_minCount, _maxCount);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;

        Vector3 center = transform.position;
        Vector3 size = new Vector3(_xOffset * 2, 0, _zOffset * 2);
        Gizmos.DrawWireCube(center, size);

        foreach (Transform child in transform)
        {
            Gizmos.DrawSphere(child.position, _gizmoRadius);
            Gizmos.DrawLine(transform.position, child.position);
        }
    }
}
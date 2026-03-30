using UnityEngine;

public abstract class Generator : MonoBehaviour
{
    [Header("Основные настройки генерации")]
    [SerializeField] protected int MinCount = 3;
    [SerializeField] protected int MaxCount = 5;
    [SerializeField] protected float XOffset = 10f;
    [SerializeField] protected float ZOffset = 10f;
    [SerializeField] protected float YOffset = 1f;

    [Header("Визуализация")]
    [SerializeField] protected Color GizmoColor = Color.green;
    [SerializeField] protected float GizmoRadius = 0.5f;

    protected virtual Vector3 CalculateRandomPosition()
    {
        float x = Random.Range(transform.position.x - XOffset, transform.position.x + XOffset);
        float z = Random.Range(transform.position.z - ZOffset, transform.position.z + ZOffset);
        float y = transform.position.y + YOffset;

        return new Vector3(x, y, z);
    }

    protected int GetRandomCount()
    {
        return Random.Range(MinCount, MaxCount);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = GizmoColor;

        Vector3 center = transform.position;
        Vector3 size = new Vector3(XOffset * 2, 0, ZOffset * 2);
        Gizmos.DrawWireCube(center, size);

        foreach (Transform child in transform)
        {
            Gizmos.DrawSphere(child.position, GizmoRadius);
            Gizmos.DrawLine(transform.position, child.position);
        }
    }
}
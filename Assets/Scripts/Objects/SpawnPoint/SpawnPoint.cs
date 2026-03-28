using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Target Target {  get; private set; }
    public Transform GetTransform => transform;
    public Color Color { get; private set; }
    public string Type { get; private set; }

    public void Init(Vector3 position, string type, Color color, Target target)
    {
        transform.position = position;
        Type = type;
        Color = color;
        Target = target;
    }
}

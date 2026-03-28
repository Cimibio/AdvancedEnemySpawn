using UnityEngine;

[RequireComponent(typeof(Transform))]
public class SpawnPoint : MonoBehaviour
{
    public Target Target {  get; set; }
    public Transform GetTransform => transform;
    public Color Color { get; set; }
    public string Type { get; set; }
}

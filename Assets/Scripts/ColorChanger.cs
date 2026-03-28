using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] Color _defaultColor;

    private void SetRandomColor(var cube)
    {
        if (cube.TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = Random.ColorHSV();
        }
    }

    public void SetDefaultColor()
    {
        if (cube.TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = _defaultColor;
        }
    }
}

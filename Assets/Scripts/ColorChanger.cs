using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] Color _defaultColor = Color.white;
    Renderer _renderer;

    private void OnEnable()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetColor(Color newColor)
    {
        _renderer.material.color  = newColor; 
    }

    private void SetRandomColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }

    public void SetDefaultColor()
    {
        _renderer.material.color = _defaultColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCapsule : MonoBehaviour
{
    Color _color;

    [SerializeField] Renderer _renderer;

    public Color GetColor() => _color;


    public void SetColor(Color newColor)
    {
        _color = newColor;
        _renderer.materials[1].color = _color;
    }
}

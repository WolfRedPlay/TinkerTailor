using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[RequireComponent(typeof(EmissionManager))]
public class Paintable : MonoBehaviour
{
    Renderer _renderer;

    Color _startColor;
    float _changeColorSpeed = Speeds.PaintSpeed;

    float _colorThreshold = .2f;

    public bool IsActive = true;

    public Action<Color> OnColorChanged;


    private void Start()
    {

        _renderer = GetComponent<Renderer>();

        _startColor = _renderer.material.color;

        IsActive = true;
    }


    public void SetColor(Color newColor)
    {
        _renderer.material.color = newColor;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Sponge") && IsActive)
        {
            if (collision.gameObject.GetComponent<Cleaner>().IsMoving)
            {
                if (_renderer.material.color != _startColor)
                {
                    if (IsColorClose(_renderer.material.color, _startColor, _colorThreshold))
                    {
                        SetColor(_startColor);
                        OnColorChanged?.Invoke(_startColor);
                    }
                    else
                        SetColor(Color.Lerp(_renderer.material.color, _startColor, _changeColorSpeed * Time.deltaTime));
                }
                
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Paint") && IsActive)
        {
            
            PaintSpay paint = other.transform.parent.GetComponent<PaintSpay>();

            if (paint.Color != Color.clear && _renderer.material.color != paint.Color)
            {
                if (IsColorClose(_renderer.material.color, paint.Color, _colorThreshold))
                {
                    SetColor(paint.Color);
                    OnColorChanged?.Invoke(paint.Color);
                    Debug.Log("Color Changed");
                }
                else
                    SetColor(Color.Lerp(_renderer.material.color, paint.Color, _changeColorSpeed * Time.deltaTime));
            }
        }
    }

    private bool IsColorClose(Color color1, Color color2, float threshold)
    {
        float rDiff = Mathf.Abs(color1.r - color2.r);
        float gDiff = Mathf.Abs(color1.g - color2.g);
        float bDiff = Mathf.Abs(color1.b - color2.b);
        float aDiff = Mathf.Abs(color1.a - color2.a);

        return (rDiff + gDiff + bDiff + aDiff) < threshold;
    }

    
}

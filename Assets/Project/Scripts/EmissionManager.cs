using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class EmissionManager : MonoBehaviour
{
    Renderer _renderer;
    List<Material> _materials;
    List<Color> _baseColors = new List<Color>();

    bool _enabled = false;

    float speed = .5f;

    Color _emissionColor;

    Paintable _paintable;

    private void Awake()
    {
        TryGetComponent<Paintable>(out _paintable);


        _renderer = GetComponent<Renderer>();

        _materials = _renderer.materials.ToList();

        _enabled = false;
    }

    public void StartEmission()
    {
        if (!_enabled)
        {
            _baseColors.Clear();

            foreach (Material mat in _materials) 
            {
                _baseColors.Add(mat.color);
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", Color.black);
            }
            _emissionColor = ConstantColors.CommonEmissionColor;
            _enabled = true;
        }
    }
    
    public void StartEmission(bool isCorrect)
    {

        _baseColors.Clear();
        foreach (Material mat in _materials)
        {
            _baseColors.Add(mat.color);
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", Color.black);
        }

        if (isCorrect) _emissionColor = ConstantColors.CorrectEmissionColor;
        else _emissionColor = ConstantColors.WrongEmissionColor;

        if (_paintable != null) _paintable.IsActive = false;
        
        StartCoroutine(Timer());

    }

    public void StopEmission()
    {
        _enabled = false;

        if (_baseColors.Count > 0)
        {
            for (int i = 0; i < _materials.Count; i++)
            {
                _materials[i].DisableKeyword("_EMISSION");
                _materials[i].color = _baseColors[i];
            }

            if (_paintable != null) _paintable.IsActive = true;
        }


    }

    private void Update()
    {
        if (_enabled) 
        {
            float t = Mathf.PingPong(Time.time * speed, 1f);

            Color finalEmissionColor = Color.Lerp(Color.black, _emissionColor, t);
            foreach (Material mat in _materials)
                mat.SetColor("_EmissionColor", finalEmissionColor);

            for (int i = 0; i < _materials.Count; i++)
            {
                Color finalBaseColor = Color.Lerp(_baseColors[i], _emissionColor, t);
                _materials[i].color = finalBaseColor;
            }

        } 
    }

    IEnumerator Timer()
    {
        float time = 0.1f;

        bool isEnable = true;


        while (isEnable)
        {
            yield return null;
            time += Time.deltaTime * speed;

            float temp = Mathf.PingPong(time, .7f);

            Color finalEmissionColor = Color.Lerp(Color.black, _emissionColor, temp);
            foreach (Material mat in _materials)
                mat.SetColor("_EmissionColor", finalEmissionColor);

            for (int i = 0; i < _materials.Count; i++)
            {
                Color finalBaseColor = Color.Lerp(_baseColors[i], _emissionColor, temp);
                _materials[i].color = finalBaseColor;
            }


            if (temp <= 0.1f) isEnable = false;
        }
        yield return null;
        StopEmission();
    }
}

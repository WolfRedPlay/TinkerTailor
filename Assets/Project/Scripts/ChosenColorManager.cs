using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Tweenables.Primitives;

public class ChosenColorManager : MonoBehaviour
{
    Image _image;

    public Color ChosenColor { get; set; }

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.color = Color.clear;

        EventManager.AddListener<ColorButtonPressedEvent>(OnColorButtonPressed);
    }

    private void OnColorButtonPressed(ColorButtonPressedEvent evt)
    {
        SetColor(evt.ChosenColor);
    }

    private void SetColor(Color newColor)
    {
        ChosenColor = newColor;
        _image.color = ChosenColor;
    }
}

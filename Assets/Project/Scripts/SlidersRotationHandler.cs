using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidersRotationHandler : MonoBehaviour
{
    [SerializeField] Slider sliderX;
    [SerializeField] Slider sliderY;
    [SerializeField] Slider sliderZ;

    [SerializeField] GameObject coloredProsthetic;

    Vector3 newRotation = Vector3.zero;

    private void Start()
    {
        coloredProsthetic.transform.eulerAngles = Vector3.zero;

        sliderX.value = 0;
        sliderY.value = 0;
        sliderZ.value = 0;

        sliderX.onValueChanged.AddListener(ChangeXRotation);
        sliderY.onValueChanged.AddListener(ChangeYRotation);
        sliderZ.onValueChanged.AddListener(ChangeZRotation);
    }

    private void ChangeZRotation(float value)
    {
        newRotation.z = value * 10;

        UpdateRotation();
    }

    private void ChangeYRotation(float value)
    {
        newRotation.y = value * 10;

        UpdateRotation();
    }

    private void ChangeXRotation(float value)
    {
        newRotation.x = value * 10;

        UpdateRotation();
    }

    private void UpdateRotation()
    {
        coloredProsthetic.transform.eulerAngles = newRotation;
    }
}

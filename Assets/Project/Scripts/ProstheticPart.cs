using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Paintable))]
[RequireComponent(typeof(EmissionManager))]
public class ProstheticPart : MonoBehaviour
{
    [SerializeField] PartType partType;
    [SerializeField] AudioSource correctSound;
    [SerializeField] AudioSource wrongSound;
    public PartType PartType => partType;

    Paintable _paint;
    Cleaning _clean;
    EmissionManager _emission;

    private void Start()
    {
        _emission = GetComponent<EmissionManager>();

        _paint = GetComponent<Paintable>();

        _paint.OnColorChanged += ColorChanged;
    }

    public void SetClean(Cleaning newClean)
    {
        _clean = newClean;
        _clean.OnCleaningFinished += Cleaned;
    }

    private void Cleaned()
    {
        PartCleanedEvent evt = new PartCleanedEvent();

        evt.PartType = partType;

        EventManager.Broadcast(evt);
    }


    private void ColorChanged(Color color)
    {
        PartColorChangedEvent evt = new PartColorChangedEvent();

        evt.Color = color;
        evt.ProstheticPart = this;

        EventManager.Broadcast(evt);
    }

    public void ChangeColor(Color newColor)
    {
        _paint.SetColor(newColor);
    }

    public void HighlightPart(bool isCorrect)
    {
        _emission.StartEmission(isCorrect);
        if (isCorrect) correctSound.Play();
        else wrongSound.Play(); 
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveChangeColor : Objective
{

    public List<ColorAssignment> ColorsScheme = new List<ColorAssignment>();

    public override void OnStart()
    {
        isDone = false;

        hint = "Paint as on hologram";

        EventManager.AddListener<PartColorChangedEvent>(CheckChangedColor);

    }

    private void CheckChangedColor(PartColorChangedEvent evt)
    {
        int index = ColorsScheme.FindIndex(x => x.PartType == evt.ProstheticPart.PartType);

        if (index != -1)
        {
            if (evt.Color == ColorsScheme[index].Color)
            {
                ColorAssignment changedAssignment = ColorsScheme[index];
                changedAssignment.isDone = true;
                ColorsScheme[index] = changedAssignment;
                evt.ProstheticPart.HighlightPart(true);
            }
            else
            {
                evt.ProstheticPart.HighlightPart(false);
            }
        }

        CheckForObjectiveCompleted();
    }

    private void CheckForObjectiveCompleted()
    {
        bool checker = true;

        foreach (ColorAssignment c in ColorsScheme)
        {
            if (!c.isDone)
            {
                checker = false;
                break;
            }
        }

        if (checker)
        {
            EventManager.RemoveListener<PartColorChangedEvent>(CheckChangedColor);

            ChangeColorObjectiveFinishedEvent evt = new ChangeColorObjectiveFinishedEvent();

            EventManager.Broadcast(evt);

            FinishObjective();
        }
    }
}

public struct ColorAssignment
{
    public PartType PartType;
    public Color Color;
    public bool isDone;


    public ColorAssignment(PartType partType, Color color)
    {
        PartType = partType;
        Color = color;
        isDone = false;
    }
}

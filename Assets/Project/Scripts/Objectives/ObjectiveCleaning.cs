using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCleaning : Objective
{
    List<PartType> _dirtParts = new List<PartType>();

    public List<PartType> DirParts => _dirtParts;

    public void AddPartToClean(PartType newPart)
    {
        _dirtParts.Add(newPart);
    }


    public override void OnStart()
    {
        isDone = false;
        hint = "Clean the prosthetic";
        EventManager.AddListener<PartCleanedEvent>(CheckForFullCleaning);
    }

    private void CheckForFullCleaning(PartCleanedEvent evt)
    {
        if (_dirtParts.Contains(evt.PartType)) _dirtParts.Remove(evt.PartType);

        if (_dirtParts.Count == 0)
        {
            EventManager.RemoveListener<PartCleanedEvent>(CheckForFullCleaning);

            CleaningObjectiveFinishedEvent newEvt = new CleaningObjectiveFinishedEvent();

            EventManager.Broadcast(newEvt);

            FinishObjective();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectiveReplaceSegment : Objective
{
    public SegmentType RequiredSegmentType { get; set; }



    public ObjectiveReplaceSegment (SegmentType segmentType)
    {
        RequiredSegmentType = segmentType; 
    }




    public override void OnStart()
    {
        isDone = false;


        switch (RequiredSegmentType) 
        { 
            case SegmentType.ENGINE:
                hint = "Replace the engine";
                break;
            
            case SegmentType.CPU:
                hint = "Replace the CPU";
                break;
            
            case SegmentType.BATERRY:
                hint = "Replace the battery";
                break;
        }
        EventManager.AddListener<SegmentConnectedEvent>(CheckConnection);

    }

    private void CheckConnection(SegmentConnectedEvent evt)
    {
        if (evt.SegmentType == RequiredSegmentType && !evt.IsBroken)
        {
            ReplaceObjectiveFinishedEvent newEvt = new ReplaceObjectiveFinishedEvent();

            newEvt.SegmentType = RequiredSegmentType;

            EventManager.Broadcast(newEvt);

            EventManager.RemoveListener<SegmentConnectedEvent>(CheckConnection);
            FinishObjective();
        }
    }
}

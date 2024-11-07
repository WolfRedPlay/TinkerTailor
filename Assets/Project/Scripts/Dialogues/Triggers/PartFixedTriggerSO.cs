using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Part_Detach_Trigger", menuName = "Triggers/PartFixed")]
public class PartFixedTriggerSO : TriggerSO
{
    [SerializeField] SegmentType requiredSegmentType;

    public override void CheckTrigger<T>(T evnt)
    {
        if (requiredSegmentType == SegmentType.ANY) ActivateTrigger();
        else 
        if ((evnt as ReplaceObjectiveFinishedEvent).SegmentType == requiredSegmentType)
        {
            ActivateTrigger();
        }

    }

    public override void OnTriggerCreated()
    {
        EventManager.AddListener<ReplaceObjectiveFinishedEvent>(CheckTrigger);
    }

    public override void OnTriggerDestroyed()
    {
        EventManager.RemoveListener<ReplaceObjectiveFinishedEvent>(CheckTrigger);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Part_Detach_Trigger", menuName = "Triggers/PartDetach")]
public class PartDetachTriggerSO : TriggerSO
{
    [SerializeField] SegmentType requiredSegmentType;


    public override void OnTriggerCreated()
    {
        EventManager.AddListener<SegmentDisconnectedEvent>(CheckTrigger);
    }

    public override void OnTriggerDestroyed()
    {
        EventManager.RemoveListener<SegmentDisconnectedEvent>(CheckTrigger);
    }

    public override void CheckTrigger<T>(T evnt)
    {
        if (requiredSegmentType == SegmentType.ANY) ActivateTrigger();
        else
        if ((evnt as SegmentDisconnectedEvent).SegmentType == requiredSegmentType)
        {
            ActivateTrigger();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Part_Detach_Trigger", menuName = "Triggers/PartCleaned")]
public class PartCleanedTriggerSO : TriggerSO
{
    [SerializeField] PartType requiredPart;


    public override void CheckTrigger<T>(T evnt)
    {
        if (requiredPart == PartType.ANY) ActivateTrigger();
        else if ((evnt as PartCleanedEvent).PartType == requiredPart)
        {
            ActivateTrigger();
        }
    }

    public override void OnTriggerCreated()
    {
        EventManager.AddListener<PartCleanedEvent>(CheckTrigger);
    }

    public override void OnTriggerDestroyed()
    {
        EventManager.RemoveListener<PartCleanedEvent>(CheckTrigger);
    }
}

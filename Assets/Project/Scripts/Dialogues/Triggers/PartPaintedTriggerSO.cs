using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Part_Detach_Trigger", menuName = "Triggers/PartPainted")]
public class PartPaintedTriggerSO : TriggerSO
{
    [SerializeField] PartType requiredPart;

    public override void CheckTrigger<T>(T evnt)
    {
        if (requiredPart == PartType.ANY) ActivateTrigger();
        else if ((evnt as PartColorChangedEvent).ProstheticPart.PartType == requiredPart) ActivateTrigger();
    }

    public override void OnTriggerCreated()
    {
        EventManager.AddListener<PartColorChangedEvent>(CheckTrigger);
    }

    public override void OnTriggerDestroyed()
    {
        EventManager.RemoveListener<PartColorChangedEvent>(CheckTrigger);
    }
}

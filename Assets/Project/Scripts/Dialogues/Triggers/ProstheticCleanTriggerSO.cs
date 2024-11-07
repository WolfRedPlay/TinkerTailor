using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Part_Detach_Trigger", menuName = "Triggers/FullyCleaned")]
public class ProstheticCleanTriggerSO : TriggerSO
{
    public override void CheckTrigger<T>(T evnt)
    {
        ActivateTrigger();
    }

    public override void OnTriggerCreated()
    {
        EventManager.AddListener<CleaningObjectiveFinishedEvent>(CheckTrigger);
    }

    public override void OnTriggerDestroyed()
    {
        EventManager.RemoveListener<CleaningObjectiveFinishedEvent>(CheckTrigger);
    }

}

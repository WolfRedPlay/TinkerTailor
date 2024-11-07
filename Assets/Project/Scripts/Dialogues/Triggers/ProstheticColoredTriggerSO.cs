using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Part_Detach_Trigger", menuName = "Triggers/FullyColored")]
public class ProstheticColoredTriggerSO : TriggerSO
{
    public override void CheckTrigger<T>(T evnt)
    {
        ActivateTrigger();
    }

    public override void OnTriggerCreated()
    {
        EventManager.AddListener<ChangeColorObjectiveFinishedEvent>(CheckTrigger);
    }

    public override void OnTriggerDestroyed()
    {
        EventManager.RemoveListener<ChangeColorObjectiveFinishedEvent>(CheckTrigger);
    }
}

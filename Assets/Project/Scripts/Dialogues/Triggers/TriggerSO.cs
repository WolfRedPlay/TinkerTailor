using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class TriggerSO : ScriptableObject
{
    public Action OnTriggerActivated;
    public abstract void OnTriggerCreated();
    public abstract void OnTriggerDestroyed();

    public abstract void CheckTrigger<T> (T evnt);

    public void ActivateTrigger()
    {
        OnTriggerActivated?.Invoke();
        OnTriggerActivated = null;
        OnTriggerDestroyed();
        //Destroy(this);
    }
    
}

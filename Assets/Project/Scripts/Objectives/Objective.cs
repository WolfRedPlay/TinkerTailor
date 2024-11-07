using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Objective
{
    protected bool isDone = false;
    public bool IsDone => isDone;

    protected string hint = string.Empty;
    public string Hint => hint;


    public List<ObjectiveUIElement> uiElement = new List<ObjectiveUIElement>();

    public abstract void OnStart();

    protected void FinishObjective()
    {
        isDone = true;
        foreach (ObjectiveUIElement element in uiElement)
            element.SetCheckBox(true);
        ObjectivesList objList = GameObject.FindAnyObjectByType<ObjectivesList>();
        
        if (objList.ObjectivesDone())
        {
            OrderFinished evt = new OrderFinished();

            EventManager.Broadcast(evt);
        }
    }

}

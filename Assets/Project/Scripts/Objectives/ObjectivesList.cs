using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesList : MonoBehaviour
{
    List<Objective> _currentObjectives = new List<Objective>();

    public List<Objective> Objectives => _currentObjectives;

    public void AddObjective(Objective newObjective)
    {
        _currentObjectives.Add(newObjective);
        newObjective.OnStart();
    }

    public bool ObjectivesDone()
    {
        foreach (Objective obj in _currentObjectives) 
        {
            Debug.Log(obj.IsDone);
            if (!obj.IsDone) return false;
        }
        return true;

    }

    public void ClearObjectives()
    {
        _currentObjectives.Clear();
    }


}

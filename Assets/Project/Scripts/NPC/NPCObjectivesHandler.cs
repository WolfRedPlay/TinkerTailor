using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObjectivesHandler : MonoBehaviour
{
    protected List<Objective> objectivesToAdd = new List<Objective>();
    public List<Objective> Objectives => objectivesToAdd;

    public void AddObjective(Objective newObjective)
    {
        objectivesToAdd.Add(newObjective);
    }

}

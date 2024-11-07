using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObjectives : NPCObjectivesHandler
{
    void Awake()
    {
        AddObjective(new ObjectiveReplaceSegment(SegmentType.CPU));

        ObjectiveChangeColor objectiveChangeColor = new ObjectiveChangeColor();
        objectiveChangeColor.ColorsScheme.Add(new ColorAssignment(PartType.FOREARM, ConstantColors.GetColor(Colors.BASIC_RED)));

        AddObjective(objectiveChangeColor);



        ObjectiveCleaning newCleanObjective = new ObjectiveCleaning();

        newCleanObjective.AddPartToClean(PartType.FOREARM);

        AddObjective(newCleanObjective);
    }
}

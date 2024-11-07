using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviVosObjectives : NPCObjectivesHandler
{
    void Awake()
    {
        AddObjective(new ObjectiveReplaceSegment(SegmentType.BATERRY));
        AddObjective(new ObjectiveReplaceSegment(SegmentType.CPU));
        AddObjective(new ObjectiveReplaceSegment(SegmentType.ENGINE));

        ObjectiveChangeColor objectiveChangeColor = new ObjectiveChangeColor();
        objectiveChangeColor.ColorsScheme.Add(new ColorAssignment(PartType.ELBOW, ConstantColors.GetColor(Colors.CYBERPUNK_TOXIC)));
        objectiveChangeColor.ColorsScheme.Add(new ColorAssignment(PartType.ENGINE_LID, ConstantColors.GetColor(Colors.CYBERPUNK_ELECTRIC)));
        objectiveChangeColor.ColorsScheme.Add(new ColorAssignment(PartType.EXTRA_SHOULDER, ConstantColors.GetColor(Colors.CYBERPUNK_TOXIC)));
        objectiveChangeColor.ColorsScheme.Add(new ColorAssignment(PartType.FOREARM, ConstantColors.GetColor(Colors.BASIC_BLUE)));
        objectiveChangeColor.ColorsScheme.Add(new ColorAssignment(PartType.CPU_LID, ConstantColors.GetColor(Colors.CYBERPUNK_ELECTRIC)));
        objectiveChangeColor.ColorsScheme.Add(new ColorAssignment(PartType.BATTERY_LID, ConstantColors.GetColor(Colors.CYBERPUNK_ELECTRIC)));
        objectiveChangeColor.ColorsScheme.Add(new ColorAssignment(PartType.UPPER_ARM, ConstantColors.GetColor(Colors.BASIC_BLUE)));
        objectiveChangeColor.ColorsScheme.Add(new ColorAssignment(PartType.EXTRA_FOREARM, ConstantColors.GetColor(Colors.CYBERPUNK_ELECTRIC)));
        objectiveChangeColor.ColorsScheme.Add(new ColorAssignment(PartType.HAND, ConstantColors.GetColor(Colors.BASIC_WHITE)));
        objectiveChangeColor.ColorsScheme.Add(new ColorAssignment(PartType.SHOULDER, ConstantColors.GetColor(Colors.BASIC_WHITE)));

        AddObjective(objectiveChangeColor);



        ObjectiveCleaning newCleanObjective = new ObjectiveCleaning();

        newCleanObjective.AddPartToClean(PartType.ELBOW);
        newCleanObjective.AddPartToClean(PartType.ENGINE_LID);
        newCleanObjective.AddPartToClean(PartType.EXTRA_SHOULDER);
        newCleanObjective.AddPartToClean(PartType.FOREARM);
        newCleanObjective.AddPartToClean(PartType.CPU_LID);
        newCleanObjective.AddPartToClean(PartType.BATTERY_LID);
        newCleanObjective.AddPartToClean(PartType.UPPER_ARM);
        newCleanObjective.AddPartToClean(PartType.EXTRA_FOREARM);
        newCleanObjective.AddPartToClean(PartType.HAND);
        newCleanObjective.AddPartToClean(PartType.SHOULDER);

        AddObjective(newCleanObjective);
    }
}

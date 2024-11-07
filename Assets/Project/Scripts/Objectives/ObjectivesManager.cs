using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    [SerializeField] ObjectivesList playersObjectives;
    [SerializeField] ProstheticManager coloredProsthetic;
    [SerializeField] ProstheticManager prosthetic;
    [SerializeField] Material baseDirtMaterial;

    [SerializeField] LidManager CPULid;
    [SerializeField] LidManager EngineLid;
    [SerializeField] LidManager BatteryLid;

    [SerializeField] GameObject finishTrigger;



    List<ObjectivesUI> _objectivesUIs;

    

    private void Start()
    {
        _objectivesUIs = GameObject.FindObjectsOfType<ObjectivesUI>(true).ToList();

        finishTrigger.SetActive(false);

        EventManager.AddListener<OrderFinished>(ActivateFinishTrigger);
    }

    private void ActivateFinishTrigger(OrderFinished finished)
    {
        finishTrigger.SetActive(true);
    }

    public void AddObjective(Objective newObjective)
    {
        CheckForChangeColorObjective(newObjective);
        CheckForCleaningObjective(newObjective);
        CheckForReplaceObjective(newObjective);

        playersObjectives.AddObjective(newObjective);
        foreach (ObjectivesUI objectivesUI in _objectivesUIs)
        {
            objectivesUI.AddObjective(newObjective);
        }
    }

    private void CheckForReplaceObjective(Objective newObjective)
    {
        if (newObjective is ObjectiveReplaceSegment)
        {
            switch ((newObjective as ObjectiveReplaceSegment).RequiredSegmentType)
            {
                case SegmentType.ENGINE:
                    EngineLid.HighlightBolt(newObjective);
                    break;

                case SegmentType.CPU:
                    CPULid.HighlightBolt(newObjective);
                    break;

                case SegmentType.BATERRY:
                    BatteryLid.HighlightBolt(newObjective);
                    break;
            }
        }
    }

    private void CheckForCleaningObjective(Objective newObjective)
    {
        if (newObjective is ObjectiveCleaning)
        {
            foreach (PartType part in (newObjective as ObjectiveCleaning).DirParts)
            {
                ProstheticPart partToAddDirt = prosthetic.Parts.Find(x => x.PartType == part);

                Cleaning newCleaning = partToAddDirt.gameObject.AddComponent<Cleaning>();
                newCleaning.AssignMaterial(baseDirtMaterial);
                newCleaning.CreateDirtObject();

                partToAddDirt.SetClean(newCleaning);
            }
        }
    }

    private void CheckForChangeColorObjective(Objective newObjective)
    {
        if (newObjective is ObjectiveChangeColor)
        {
            foreach (ProstheticPart part in coloredProsthetic.Parts)
            {
                ColorAssignment assignment = (newObjective as ObjectiveChangeColor).ColorsScheme.Find(x => x.PartType == part.PartType);
                if (!assignment.Equals(default(ColorAssignment)))
                {
                    part.ChangeColor(assignment.Color);
                }
            }

        }
    }

    public void ClearObjectives()
    {
        playersObjectives.ClearObjectives();
        foreach (ObjectivesUI objectivesUI in _objectivesUIs)
        {
            objectivesUI.ClearObjectives();
        }
    }
}

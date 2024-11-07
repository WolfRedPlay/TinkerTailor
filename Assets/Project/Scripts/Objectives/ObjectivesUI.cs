
using UnityEngine;

public class ObjectivesUI : MonoBehaviour
{
    [SerializeField] RectTransform objectivesList;
    [SerializeField] GameObject objectivePrefab;

    //List<>

    public void AddObjective(Objective newObjective)
    {
        GameObject newObj = Instantiate(objectivePrefab, objectivesList);

        ObjectiveUIElement newObjectiveElement = newObj.GetComponent<ObjectiveUIElement>();
        newObjectiveElement.SetHintText(newObjective.Hint);
        newObjectiveElement.SetCheckBox(false);

        newObjective.uiElement.Add(newObjectiveElement);
    }

    public void ClearObjectives()
    {
        for(int i = 0; i < objectivesList.childCount; i++)
        {
            Destroy(objectivesList.GetChild(i).gameObject);
        }
    }
}

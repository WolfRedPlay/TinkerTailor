using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraceletWindowsManager : MonoBehaviour
{
    [SerializeField] GameObject startWindow;
    [SerializeField] GameObject objectiveWindow;

    public void OpenObjectiveWindow()
    {
        startWindow.SetActive(false);
        objectiveWindow.SetActive(true);
    }
    
    public void OpenStartWindow()
    {
        objectiveWindow.SetActive(false);
        startWindow.SetActive(true);
    }

    public void CloseAllPanels()
    {
        objectiveWindow.SetActive(false);
        startWindow.SetActive(false);
    }
}

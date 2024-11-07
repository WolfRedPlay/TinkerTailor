using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PalletsManager : MonoBehaviour
{
    [SerializeField] List<GameObject> pallets;

    [SerializeField] Button nextButton;
    [SerializeField] Button previousButton;


    int _currentPallet = 0;


    private void Start()
    {
        _currentPallet = 0;
    }

    public void OpenNextPallet()
    {
        pallets[_currentPallet].SetActive(false);

        if (_currentPallet == 0)
        {
            previousButton.interactable = true;
        }
        _currentPallet++;
        pallets[_currentPallet].SetActive(true);

        if (_currentPallet == pallets.Count - 1)
        {
            nextButton.interactable = false;
        }
    }

    public void OpenPreviousPallet() 
    {
        pallets[_currentPallet].SetActive(false);
       
        if (_currentPallet == pallets.Count - 1)
        {
            nextButton.interactable = true;
        }

        _currentPallet--;
        pallets[_currentPallet].SetActive(true);

        if (_currentPallet == 0)
        {
            previousButton.interactable = false;
        }
    }
    
}

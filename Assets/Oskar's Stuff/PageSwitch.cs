using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageSwitch : MonoBehaviour
{
    [SerializeField] GameObject currentPage;
    [SerializeField] GameObject turnPage;

    public void TurnPage()
    {
        if (turnPage != null)
        {
            turnPage.SetActive(true);
            currentPage.SetActive(false);
        }
    }
}

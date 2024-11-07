using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bracelet : MonoBehaviour
{
    [SerializeField] BraceletWindowsManager braceletWindowManager;

    [SerializeField] GameObject hand;

    [SerializeField] IndicatorManager indicator;

    [SerializeField] GameObject anotherBracelet;

    AudioSource _sound;


    bool hidden = true;

    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        indicator.ProcessFinished.AddListener(ShowPanel);
        hidden = true;
    }

    public void ShowPanel()
    {
        braceletWindowManager.OpenStartWindow();
        _sound.Play();
        hidden = false;
    }

    public void StartOpening()
    {
        if (hidden)
        {
            indicator.StartProcess();
        }
    }


    public void HidePanel()
    {
        braceletWindowManager.CloseAllPanels();
        hidden = true;
    }



    private void Update()
    {
        if (!hidden)
        {
            if (/*(hand.transform.rotation.eulerAngles.x < 30 && hand.transform.rotation.eulerAngles.x > -30) &&*/
                (hand.transform.rotation.eulerAngles.z < 30 && hand.transform.rotation.eulerAngles.z > -30))
            {
                HidePanel();
            }
        }
    }


    public void StopOpening()
    {
        indicator.StopProcess();

    }

    public void ChangeHand()
    {
        anotherBracelet.gameObject.SetActive(true);
        anotherBracelet.GetComponent<Bracelet>().ShowPanel();
        HidePanel();
        gameObject.SetActive(false);
    }
}

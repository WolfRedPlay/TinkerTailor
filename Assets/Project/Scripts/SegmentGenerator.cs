using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SegmentGenerator : MonoBehaviour
{
    [SerializeField] DroneManager drone;

    [SerializeField] GameObject enginePrefab;
    [SerializeField] GameObject CPUPrefab;
    [SerializeField] GameObject batteryPrefab;
    [SerializeField] AudioSource buySound;

    [SerializeField] List<Button> buyButtons;

    private void StartDroneWithSegment(GameObject segment)
    {
        if (drone.IsDroneFree())
        {
            buySound.Play();
            drone.CreateSegment(segment);
            drone.StartAnimation();
        }
    }


    public void BuyBattery()
    {
        StartDroneWithSegment(batteryPrefab);
    }
    
    public void BuyCPU()
    {
        StartDroneWithSegment(CPUPrefab);
    }
    
    public void BuyEngine()
    {
        StartDroneWithSegment(enginePrefab);
    }

    private void Update()
    {
        if (drone.IsDroneFree())
        {
            foreach (var but in buyButtons)
            {
                if (!but.interactable) but.interactable = true;
            }
        }
        else
        {
            foreach (var but in buyButtons)
            {
                if (but.interactable) but.interactable = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class clockUpdate : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> clockTexts;
    [SerializeField] float hourLegnthMult = 1;
    [SerializeField] float elapsedTime;
    [SerializeField] float endTime;
    [SerializeField] bool clockRunning;
    float timePassed;

    private void Start()
    {
        timePassed = elapsedTime * 60;
        float endTimeUse = endTime * 60;


        int minutes = Mathf.FloorToInt(timePassed % 60);
        int hours = Mathf.FloorToInt(timePassed / 60) % 24;

        foreach (var clock in clockTexts) {
            clock.text = string.Format("{0:00}:{1:00}", hours, minutes);

        }

        clockRunning = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (clockRunning == true)
        {
            timePassed += Time.deltaTime * hourLegnthMult;
            int minutes = Mathf.FloorToInt(timePassed % 60);
            int hours = Mathf.FloorToInt(timePassed / 60) % 24;

            foreach (var clock in clockTexts)
            {
                clock.text = string.Format("{0:00}:{1:00}", hours, minutes);

            }

            if (hours + minutes == endTime)
            {
                clockRunning = false;
            }
        }
    }

    public void StartClock()
    {
        clockRunning = true;
    }
}

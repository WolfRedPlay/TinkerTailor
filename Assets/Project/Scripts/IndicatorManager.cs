using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IndicatorManager : MonoBehaviour
{
    Image _image;

    float processAmount = 0f;
    float processSpeed = 0.9f;

    public UnityEvent ProcessFinished;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void StartProcess()
    {
        
        StartCoroutine(Process());
    }

    public void StopProcess()
    {
        StopAllCoroutines();
        processAmount = 0f;
        _image.fillAmount = processAmount;
    }


    IEnumerator Process()
    {
        processAmount = 0f;
        _image.fillAmount = processAmount;
        while (processAmount < 1f)
        {
            yield return null;
            processAmount += processSpeed * Time.deltaTime;
            _image.fillAmount = processAmount;
        }

        processAmount = 0f;
        _image.fillAmount = processAmount;
        ProcessFinished?.Invoke();
        yield return null;
    }
}

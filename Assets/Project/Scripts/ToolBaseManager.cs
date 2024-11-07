using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ToolBaseManager : MonoBehaviour
{
    [SerializeField] Transform attachPoint;

    [SerializeField] ParticleSystem particles;

    [SerializeField] Light baseLight;

    [SerializeField] float maxLightIntensity = 0.05f;

    [SerializeField] float lightSpeed = .05f;



    XRSocketInteractor _socket;

    Transform _toolTransform = null;

    AudioSource _sound;
    private void Start()
    {
        _sound = GetComponent<AudioSource>();

        _socket = GetComponent<XRSocketInteractor>();

        _socket.selectEntered.AddListener(OnSelection);
        _socket.selectExited.AddListener(OnDeselection);

        baseLight.intensity = 0f;
        particles.Stop();
    }

    private void OnDeselection(SelectExitEventArgs arg0)
    {
        particles.Stop();
        _sound.Stop();
        StopAllCoroutines();
        if (gameObject.activeInHierarchy) StartCoroutine(TurnLightOff());
    }

    private void OnSelection(SelectEnterEventArgs arg0)
    {
        if (_toolTransform == null)
        {
            _toolTransform = arg0.interactableObject.transform;
        }

        particles.Play();
        _sound.Play();
        StopAllCoroutines();
        StartCoroutine(TurnLightOn());
    }


    public void ReturnToolBack()
    {
        if (_toolTransform != null)
        {
            _toolTransform.position = attachPoint.position;
            if(_toolTransform.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.velocity = Vector3.zero;
            }
            
        }
    }

    IEnumerator TurnLightOn()
    {
        while (baseLight.intensity < maxLightIntensity)
        {
            yield return null;
            baseLight.intensity += lightSpeed * Time.deltaTime;
        }
        yield return null;
        baseLight.intensity = maxLightIntensity;
    }
    
        
    IEnumerator TurnLightOff()
    {
        while (baseLight.intensity > 0)
        {
            yield return null;
            baseLight.intensity -= lightSpeed * Time.deltaTime;
        }
        yield return null;
        baseLight.intensity = 0;
    }

    private void OnDestroy()
    {
        _socket.selectEntered.RemoveListener(OnSelection);
        _socket.selectExited.RemoveListener(OnDeselection);
    }
}

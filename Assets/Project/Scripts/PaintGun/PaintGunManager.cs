using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PaintGunManager : MonoBehaviour
{
    [SerializeField] XRSocketInteractor capsuleSocket;
    [SerializeField] ParticleSystem particles;
    [SerializeField] PaintSpay spray;
    [SerializeField] AudioSource audioSpray;
    
    Color _color;



    private void Start()
    {
        capsuleSocket.selectEntered.AddListener(OnCapsuleConnected);
        capsuleSocket.selectExited.AddListener(OnCapsuleDisconnected);


        _color = Color.clear;
        particles.Stop();
    }

    private void OnCapsuleDisconnected(SelectExitEventArgs arg0)
    {
        _color = Color.clear;
    }

    private void OnCapsuleConnected(SelectEnterEventArgs arg0)
    {
        if (arg0.interactableObject.transform.TryGetComponent<PaintCapsule>(out PaintCapsule capsule))
        {
            SetColor(capsule.GetColor());
        }
    }

    private void SetColor(Color newColor)
    {
        _color = newColor;
        spray.Color = newColor;
        var main = particles.main;
        main.startColor = newColor;
    }

    public void StartSpraying()
    {
        if (_color != Color.clear)
        {
            if (!particles.isPlaying) particles.Play();
            if(!audioSpray.isPlaying) audioSpray.Play();
        }

    }
    
    public void StopSpraying()
    {
        if (particles.isPlaying)particles.Stop();
        if (audioSpray.isPlaying) audioSpray.Stop();

    }

}

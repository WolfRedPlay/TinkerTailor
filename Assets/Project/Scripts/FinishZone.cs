using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class FinishZone : MonoBehaviour
{
    XRSocketInteractor _socket;

    private void Awake()
    {
        _socket = GetComponent<XRSocketInteractor>();
        _socket.selectEntered.AddListener(ProstheticConnected);
    }

    private void ProstheticConnected(SelectEnterEventArgs arg0)
    {
        GameObject.FindAnyObjectByType<NPCManager>().ShowFinishDialogue();
        gameObject.SetActive(false);
    }
}

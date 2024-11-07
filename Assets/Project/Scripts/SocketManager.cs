using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.VisualScripting;


[RequireComponent(typeof(XRSocketInteractor))]
public class SocketManager : MonoBehaviour
{
    [SerializeField] LidManager lid;

    
    XRSocketInteractor _socket;
    Transform _attached;
    BoxCollider _triggerBox;
    AudioSource _sound;


    private void Start()
    {
        _sound = GetComponent<AudioSource>();

        _socket = GetComponent<XRSocketInteractor>();
        _triggerBox = GetComponent<BoxCollider>();

        _socket.selectEntered.AddListener(OnFirstConnection);

        lid.LidOpened.AddListener(ActivateSocket);
        lid.LidClosed.AddListener(DeactivateSocket);

    }




    private void OnFirstConnection(SelectEnterEventArgs arg0)
    {
        _attached = arg0.interactableObject.transform;
        _attached.SetParent(gameObject.transform);
        _socket.selectEntered.RemoveListener(OnFirstConnection);
        _socket.selectEntered.AddListener(OnConnection);

        DeactivateSocket();

    }


    private void OnDisconnection(SelectExitEventArgs arg0)
    {
        if (_attached != null)
        {
            _attached.SetParent(null);
            _attached.GetComponent<Rigidbody>().isKinematic = false;
            _attached = null;
            _sound.Play();
        }
    }



    private void OnConnection(SelectEnterEventArgs arg0)
    {
        _attached = arg0.interactableObject.transform;
        _attached.SetParent(gameObject.transform);
        _sound.Play();
    }


    public void ActivateSocket()
    {
        _socket.selectExited.AddListener(OnDisconnection);
        _triggerBox.enabled = true;
        if (_attached != null)
        {
            TurnOnPhysicsForInteractor();
        }
    }

    public void DeactivateSocket()
    {
        _socket.selectExited.RemoveListener(OnDisconnection);
        if (_triggerBox.enabled)
        {
            _triggerBox.enabled = false;
            if (_attached != null) _attached.SetParent(gameObject.transform);
        }
        if (_attached != null)
        {
            TurnOffPhysicsForInteractor();
        }
    }



    private void TurnOnPhysicsForInteractor()
    {
        _attached.GetComponent<BoxCollider>().enabled = true;
    }

    private void TurnOffPhysicsForInteractor()
    {
        _attached.GetComponent<BoxCollider>().enabled = false;
    }
}

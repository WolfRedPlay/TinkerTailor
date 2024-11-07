using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class LidManager : MonoBehaviour
{
    [SerializeField] Bolt bolt;

    XRGrabInteractable _grab;
    HingeJoint _joint;
    Rigidbody _rb;
  
    public UnityEvent LidOpened;
    public UnityEvent LidClosed;


    private void Start()
    {
        _grab = GetComponent<XRGrabInteractable>();

        _joint = GetComponent<HingeJoint>();

        _rb = GetComponent<Rigidbody>();


        bolt.BoltUnscrewed.AddListener(UnlockLid);

        LockLid();
    }


    public void HighlightBolt(Objective objectiveToAssign)
    {
        bolt.Highlight(objectiveToAssign);
    }


    public void UnlockLid()
    {
        _rb.isKinematic = false;
        _joint.useSpring = false;

        _grab.enabled = true;
        _grab.lastSelectExited.AddListener(CheckPosition);
        _grab.firstSelectEntered.AddListener(StopChecking);

        bolt.BoltUnscrewed.RemoveListener(UnlockLid);
        bolt.BoltScrewed.AddListener(LockLid);

    }

    public void LockLid()
    {
        _rb.isKinematic = true;
        _joint.useSpring = true;
        
        _grab.enabled = false;
        _grab.lastSelectExited.RemoveListener(CheckPosition);
        _grab.firstSelectEntered.RemoveListener(StopChecking);

        bolt.BoltScrewed.RemoveListener(LockLid);
        bolt.BoltUnscrewed.AddListener(UnlockLid);
    }

    private void StopChecking(SelectEnterEventArgs arg0)
    {
        bolt.HideBolt();
        _joint.useSpring = false;
        StopAllCoroutines();
    }

    private void CheckPosition(SelectExitEventArgs arg0)
    {
        StartCoroutine(Check());
    }


    IEnumerator Check()
    {
        yield return new WaitForSeconds(.1f);
        if (_joint.angle > 90)
        {
            _joint.useSpring = false;
            LidOpened?.Invoke();
        }
        else
        {

            if (_joint.angle < 60)
            {
                bolt.ShowBolt();
                _joint.useSpring = true;
            }

            LidClosed?.Invoke();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverManager : MonoBehaviour
{
    
    
    public UnityEvent OnLeverActive;
    public UnityEvent OnLeverNotActive;


    HingeJoint _joint;


    private void Start()
    {
        _joint = GetComponent<HingeJoint>();
    }


    private void Update()
    {
        if (_joint.angle >= 45)
        {
            OnLeverActive?.Invoke();
        }
        else
        {
            OnLeverNotActive?.Invoke();
        }
    }
}

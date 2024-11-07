using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneManager : MonoBehaviour
{
    [SerializeField] Transform attachPoint;
    [SerializeField] Animator _eyesAnimator;

    GameObject _segment;
    Animator _animatorMain;
    AudioSource _audioSource;


    private void Start()
    {
        _animatorMain = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }


    public void CreateSegment(GameObject newSegment)
    {


        _segment = Instantiate(newSegment, attachPoint);

        _segment.GetComponent<Rigidbody>().useGravity = false;
        _segment.GetComponent<Rigidbody>().isKinematic = true;
        _segment.GetComponent<BoxCollider>().enabled = false;

    }


    public void DetachSegment()
    {
        _segment.GetComponent<Rigidbody>().useGravity = true;
        _segment.GetComponent<Rigidbody>().isKinematic = false;
        _segment.GetComponent<BoxCollider>().enabled = true;
        _segment.transform.SetParent(null);
        _eyesAnimator.Play("Smile");
    }


    public void StartAnimation()
    {
        _animatorMain.SetBool("IsFlying", true);
        _audioSource.Play();
    }
    
    public void StopAnimation()
    {
        _animatorMain.SetBool("IsFlying", false);
        _audioSource.Stop();
    }

    public bool IsDroneFree()
    {
        bool result = _animatorMain.GetBool("IsFlying");
        return !result;
    }
}

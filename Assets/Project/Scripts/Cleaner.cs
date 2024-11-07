using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    [SerializeField] GameObject finishParticles;
    
    
    Rigidbody rb;
    [SerializeField] AudioSource cleanFinished;
    [SerializeField] AudioSource cleanSound;

    float positionTreshhold = .4f;
    float rotationTreshhold = .4f;
    private Vector3 lastPosition;
    private Quaternion lastRotation;

    float waitTime = .2f;

    bool isMoving = false;

    public bool IsMoving { get { return isMoving; } }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    void Update()
    {
        float positionDelta = Vector3.Distance(lastPosition, transform.position);

        float rotationDelta = Quaternion.Angle(lastRotation, transform.rotation);


        if (positionDelta > positionTreshhold || rotationDelta > rotationTreshhold)
        {
            isMoving = true;
            StopAllCoroutines();
        }
        else
        {
            StartCoroutine(StayTimer());
        }

        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    IEnumerator StayTimer()
    {
        yield return new WaitForSeconds(waitTime);
        isMoving = false;
    }

    public void FinishCleaning()
    {
        if (finishParticles != null) Instantiate(finishParticles, transform.position, Quaternion.identity);
        cleanFinished.Play();
    }

    public void PlayCleaningSound()
    {
        if (!cleanSound.isPlaying) cleanSound.Play();
    }

    public void StopCleaningSound() 
    {
        if(cleanSound.isPlaying) cleanSound.Stop();
    }

}

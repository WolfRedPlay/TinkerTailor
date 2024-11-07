using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Bolt : MonoBehaviour
{
    private float rotationSpeed = 90f;
    private float movementSpeed = Speeds.BoltSpeed;

    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;

    AudioSource sound;

    public UnityEvent BoltUnscrewed;
    public UnityEvent BoltScrewed;


    bool _screw = true;
    public bool IsScrew
    {
        get { return _screw; }
    }


    EmissionManager _emissionManager;

    List<Objective> _assignedObjectives = new List<Objective>();


    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        _emissionManager = GetComponent<EmissionManager>();
    }

    public void Highlight(Objective objectivesToAssign)
    {
        _emissionManager.StartEmission();
        _assignedObjectives.Add(objectivesToAssign);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Screwdriver"))
        {
            if (!sound.isPlaying) sound.Play();
            if (_screw) UnScrew();
            else Screw();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Screwdriver"))
        {
            sound.Stop();
        }
    }

    private void UnScrew()
    {
        Vector3 newPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + movementSpeed * Time.deltaTime, transform.localPosition.z);
        transform.localPosition = newPosition;

        if (transform.localPosition.y >= maxHeight)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, maxHeight, transform.localPosition.z);
            HideBolt();
            _screw = false;
            BoltUnscrewed?.Invoke();
        }

        Quaternion newRotation = Quaternion.Euler( 0, rotationSpeed * Time.deltaTime, 0);
        transform.localRotation *= newRotation;
    }

    private void Screw()
    {

        if (transform.localPosition.y == maxHeight) BoltScrewed?.Invoke();
        Vector3 newPosition = new Vector3(transform.localPosition.x ,transform.localPosition.y - movementSpeed * Time.deltaTime, transform.localPosition.z);
        transform.localPosition = newPosition;

        if (transform.localPosition.y <= minHeight)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            sound.Stop();
            StartCoroutine(ActiveDelay());
            _screw = true;
        }

        Quaternion newRotation = Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
        transform.localRotation *= newRotation;
    }

    public void HideBolt()
    {
        transform.gameObject.SetActive(false);

        sound.Stop();

    }

    public void ShowBolt()
    {
        transform.gameObject.SetActive(true);
    }


    IEnumerator ActiveDelay()
    {
        _emissionManager.StopEmission();
        yield return new WaitForSeconds(3f);


        if (CheckForObjective())
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            _emissionManager.StartEmission();
        }
            
    }




    private bool CheckForObjective()
    {
        if (_assignedObjectives == null) return false;

        foreach (Objective objective in _assignedObjectives) 
        {
            if (!objective.IsDone) return true;
        }

        return false;
        
    }
}

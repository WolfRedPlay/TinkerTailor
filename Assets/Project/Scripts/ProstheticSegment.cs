using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public enum SegmentType
{
    BATERRY,
    ENGINE,
    CPU,
    ANY
}
public class ProstheticSegment : MonoBehaviour
{
    [SerializeField] SegmentType segmentType;
    XRGrabInteractable _grab;

    [SerializeField] bool isBroken = false;

    [SerializeField] GameObject brokenParticles;


    AudioSource brokenAudioSource;
    public bool IsBroken => isBroken;


    private void Awake()
    {
        brokenAudioSource = GetComponent<AudioSource>();
        if (isBroken) brokenAudioSource.Play();
    }

    private void Start()
    {
        _grab = GetComponent<XRGrabInteractable>();

        _grab.selectExited.AddListener(SegmentDisconnected);
        _grab.selectEntered.AddListener(SegmentConnected);



        brokenParticles.SetActive(isBroken);
    }

    private void SegmentConnected(SelectEnterEventArgs arg)
    {
        if (arg.interactorObject is XRSocketInteractor && 
            (arg.interactorObject.transform.parent != null && arg.interactorObject.transform.parent.CompareTag("Prosthetic")))
        {
            SegmentConnectedEvent evt = new SegmentConnectedEvent();

            evt.SegmentType = segmentType;
            evt.IsBroken = isBroken;

            EventManager.Broadcast(evt);
        }
    }

    private void SegmentDisconnected(SelectExitEventArgs arg)
    {
        if (arg.interactorObject is XRSocketInteractor &&
        (arg.interactorObject.transform.parent != null && arg.interactorObject.transform.parent.CompareTag("Prosthetic")))
        {
            SegmentDisconnectedEvent evt = new SegmentDisconnectedEvent();
            evt.SegmentType = segmentType;
            evt.IsBroken = isBroken;
            EventManager.Broadcast(evt);
        }
    }
}

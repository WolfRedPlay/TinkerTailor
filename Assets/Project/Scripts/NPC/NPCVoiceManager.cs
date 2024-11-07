using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVoiceManager : MonoBehaviour
{
    [SerializeField] AudioSource voiceSource;


    private void Start()
    {
        EventManager.AddListener<DialogueStartedEvent>(PlayVoiceLine);
    }

    private void PlayVoiceLine(DialogueStartedEvent evt)
    {
        if (evt.VoiceLine != null)
        {
            voiceSource.clip = evt.VoiceLine;
            voiceSource.Play();
        }
    }
}

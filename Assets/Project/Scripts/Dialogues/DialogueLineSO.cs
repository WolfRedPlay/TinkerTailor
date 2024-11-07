using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
[CreateAssetMenu(fileName = "DialogueObject", menuName = "DialogueObject")]
public class DialogueLineSO : ScriptableObject
{
    [SerializeField][TextArea] public List<string> phrases;

    [SerializeField] AnimationClip animationToPlay;
    [SerializeField] AudioClip voiceLine;

    public UnityEvent OnStarted;
    public UnityEvent OnFinished;

    public AnimationClip AnimationToPlay => animationToPlay;
    public AudioClip VoiceLine => voiceLine;

    public List<string> GetPhrases()
    {
        return phrases;
    }
}

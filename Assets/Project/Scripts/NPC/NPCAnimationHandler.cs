using System;
using UnityEngine;

public class NPCAnimationHandler : MonoBehaviour
{

    Animator _animator;



    private void Start()
    {
        _animator = GetComponent<Animator>();
        EventManager.AddListener<DialogueStartedEvent>(PlayAnimation);
    }

    private void PlayAnimation(DialogueStartedEvent evt)
    {
        if (evt.AnimationName != "")
            _animator.Play(evt.AnimationName, 0);
    }

    public void SitDown()
    {
        _animator.SetBool("AtTheTable", true);
        GameObject.FindAnyObjectByType<NPCManager>().ShowIntroDialogue();
    }
    
    public void StandUp()
    {
        _animator.SetBool("AtTheTable", false);
    }


    private void OnDestroy()
    {
        EventManager.RemoveListener<DialogueStartedEvent>(PlayAnimation);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] Typing textField;
    [SerializeField] float delayBetweenPhrases = 4f;

    bool _isActive;

    Queue<DialogueLineSO> _waitingList = new Queue<DialogueLineSO>();

    private void Start()
    {
        _isActive = false;

        EventManager.AddListener<ReactionUsedEvent>(ShowReaction);
    }

    private void ShowReaction(ReactionUsedEvent evt)
    {
        ShowDialogue(evt.DialogueToStart);
    }

    public void ShowDialogue(DialogueLineSO dialogueLine)
    {
        if (!_isActive )
        {
            StartCoroutine(StepThroughDialogue(dialogueLine));
        } else
        {
            _waitingList.Enqueue(dialogueLine);
        }
    }


    IEnumerator StepThroughDialogue(DialogueLineSO dialogueLine)
    {

        dialogueLine.OnStarted?.Invoke();

        DialogueStartedEvent evt = new DialogueStartedEvent();

        if (dialogueLine.AnimationToPlay != null) evt.AnimationName = dialogueLine.AnimationToPlay.name;
        else evt.AnimationName = "";

        if (dialogueLine.VoiceLine != null) evt.VoiceLine = dialogueLine.VoiceLine;
        else evt.VoiceLine = null;

        EventManager.Broadcast(evt);


        _isActive = true;
        foreach (var phrase in dialogueLine.GetPhrases())
        {
            yield return textField.Run(phrase);

            yield return new WaitForSeconds(delayBetweenPhrases);
        }

        dialogueLine.OnFinished?.Invoke();
        textField.Clean();
        _isActive = false;
    }


    private void Update()
    {
        if (_waitingList.Count > 0 && !_isActive)
        {
            ShowDialogue(_waitingList.Dequeue());
        }
    }


    private void OnDestroy()
    {
        EventManager.RemoveListener<ReactionUsedEvent>(ShowReaction);

    }

}

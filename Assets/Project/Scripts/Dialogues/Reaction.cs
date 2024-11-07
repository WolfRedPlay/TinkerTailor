using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Reaction
{
    [SerializeField] DialogueLineSO dialogue;

    public DialogueLineSO Dialogue => dialogue;
    [SerializeField] TriggerSO trigger;

    NPCDialogueHandler _owner;

    public void SetNPC(NPCDialogueHandler newNPC)
    {
        _owner = newNPC;
    }
    
    public void RegisterReaction()
    {
        trigger.OnTriggerActivated += UseReaction;
        trigger.OnTriggerCreated();
    }


    private void UseReaction()
    {
        ReactionUsedEvent evt = new ReactionUsedEvent();
        evt.DialogueToStart = dialogue;
        EventManager.Broadcast(evt);

    }
}

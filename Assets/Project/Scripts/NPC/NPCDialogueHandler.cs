using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueHandler : MonoBehaviour
{
    [SerializeField] DialogueLineSO introDialogue;
    public DialogueLineSO IntroDialogue => introDialogue;
    
    [SerializeField] DialogueLineSO finishDialogue;
    public DialogueLineSO FinishDialogue => finishDialogue;


    [SerializeField] List<Reaction> reactions;

    private void Start()
    {

        foreach (var reaction in reactions) 
        {
            reaction.SetNPC(this);
            reaction.RegisterReaction();
        }

        //_dialogueUI.ShowDialogue(introDialogue);
    }

    public void AddReaction(Reaction reaction)
    {
        reactions.Add(reaction);
        reactions[reactions.Count - 1].SetNPC(this);
        reactions[reactions.Count - 1].RegisterReaction();

    }

    
}

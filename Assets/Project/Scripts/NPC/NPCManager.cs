using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] NPCDialogueHandler currentNPCDialogue;
    [SerializeField] NPCObjectivesHandler currentNPCObjectives;
    [SerializeField] NPCAnimationHandler currentNPCAnims;

    [SerializeField] GameObject NPCProsthetic;
    [SerializeField] GameObject prosthetic;

    public DialogueLineSO IntroDialogue => currentNPCDialogue.IntroDialogue;
    public DialogueLineSO FinalDialogue => currentNPCDialogue.FinishDialogue;


    DialogueUI _dialogueUI;

    ObjectivesManager _objectivesManager;

    private void Start()
    {
        _dialogueUI = GameObject.FindObjectOfType<DialogueUI>();

        _objectivesManager = GameObject.FindObjectOfType<ObjectivesManager>(true);

        prosthetic.SetActive(false);

        //StartCoroutine(StartDelay());
        //RegisterObjectives();
    }


    IEnumerator StartNPC()
    {
        yield return new WaitForSeconds(.5f);

        ShowIntroDialogue();
        RegisterObjectives();
    }


    public void ShowIntroDialogue()
    {
        currentNPCDialogue.IntroDialogue.OnFinished.AddListener(StartAssignments);
        _dialogueUI.ShowDialogue(currentNPCDialogue.IntroDialogue);
    }
    
    public void ShowIntroDialogue(bool isTutorial)
    {
        _dialogueUI.ShowDialogue(currentNPCDialogue.IntroDialogue);
    }
    
    public void ShowFinishDialogue()
    {
        prosthetic.SetActive(false);
        if (NPCProsthetic != null)
            NPCProsthetic.SetActive(true);
        _objectivesManager.ClearObjectives();
        if (currentNPCAnims != null)
        {
            currentNPCDialogue.FinishDialogue.OnFinished.AddListener(currentNPCAnims.StandUp);
        }
        _dialogueUI.ShowDialogue(currentNPCDialogue.FinishDialogue);
    }


    public void StartAssignments()
    {
        prosthetic.SetActive(true);
        if (NPCProsthetic != null)
            NPCProsthetic.SetActive(false);
        RegisterObjectives();
    }

    public void RegisterObjectives()
    {
        foreach (Objective objective in currentNPCObjectives.Objectives)
        {
            _objectivesManager.AddObjective(objective);
        }
    }
    public void UnregisterObjectives()
    {
        foreach (Objective objective in currentNPCObjectives.Objectives)
        {
            _objectivesManager.AddObjective(objective);
        }
    }

    public void AddReaction(Reaction newReaction)
    {
        currentNPCDialogue.AddReaction(newReaction);
    }
}

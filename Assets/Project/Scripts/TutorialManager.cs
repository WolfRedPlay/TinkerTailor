using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    NPCManager _npcManager;
    DialogueUI _dialogueUI;

    [SerializeField] GameObject prosthetic;

    [SerializeField] GameObject hologram;

    [SerializeField] List<EmissionManager> spongeEmission;

    [SerializeField] EmissionManager screwdriverEmission;
    
    [SerializeField] List<EmissionManager> paintGunEmissions;

    [SerializeField] List<Button> taskButton;

    [SerializeField] List<Button> startButton;

    [SerializeField] DialogueLineSO braceletDialogue;

    [SerializeField] DialogueLineSO holdersDialogue;

    [SerializeField] DialogueLineSO tasksDialogue;
    [SerializeField] DialogueLineSO tasksOpenedDialogue;

    [SerializeField] DialogueLineSO cleaningDialogue;
    [SerializeField] Reaction onCleaningFinished;
    
    [SerializeField] Reaction onReplacementFinished;

    [SerializeField] Reaction onPaintFinished;

    [SerializeField] DialogueLineSO finalDialogue;




    private void Start()
    {
        _dialogueUI = GameObject.FindAnyObjectByType<DialogueUI>();

        _npcManager = GameObject.FindAnyObjectByType<NPCManager>();

        prosthetic.SetActive(false);
        hologram.SetActive(false);

        _npcManager.FinalDialogue.OnFinished.AddListener(FinishTutorial);

        _npcManager.IntroDialogue.OnFinished.AddListener(StartBraceletDialogue);

        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        _npcManager.ShowIntroDialogue(true);

    }

    public void StartBraceletDialogue()
    {
        braceletDialogue.OnFinished.AddListener(StartToolHoldersDialogue);
        _dialogueUI.ShowDialogue(braceletDialogue);
    }

    public void StartToolHoldersDialogue()
    {
        foreach(var item in startButton)
            item.onClick.AddListener(StartFirstClient);
        _dialogueUI.ShowDialogue(holdersDialogue);
    }

    public void StartFirstClient()
    {
        foreach (var item in startButton)
            item.onClick.RemoveListener(StartFirstClient);
        foreach (var item in taskButton)
            item.onClick.AddListener(OnBraceletOpened);
        prosthetic.SetActive(true);
        _npcManager.RegisterObjectives();
        _dialogueUI.ShowDialogue(tasksDialogue);
    }

    public void OnBraceletOpened()
    {
        foreach (var item in taskButton)
            item.onClick.RemoveListener(OnBraceletOpened);
        _dialogueUI.ShowDialogue(tasksOpenedDialogue);
        tasksOpenedDialogue.OnFinished.AddListener(StartCleaningAssignment);

    }

    public void StartCleaningAssignment()
    {
        foreach (var item in spongeEmission)
            item.StartEmission();
        onCleaningFinished.Dialogue.OnStarted.AddListener(StartReplacementAssignment);
        _npcManager.AddReaction(onCleaningFinished);
        _dialogueUI.ShowDialogue(cleaningDialogue);
    }

    public void StartReplacementAssignment()
    {
        screwdriverEmission.StartEmission();
        onReplacementFinished.Dialogue.OnStarted.AddListener(StartPaintAssignment);
        _npcManager.AddReaction(onReplacementFinished);
    }

    public void StartPaintAssignment()
    {
        hologram.SetActive(true);
        foreach (var item in paintGunEmissions)
        {
            item.StartEmission();
        }
        _npcManager.AddReaction(onPaintFinished);
    }


    public void FinishTutorial()
    {
        SceneManager.LoadScene(0);
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestButton : MonoBehaviour
{
    [SerializeField] TMP_Text testText;
    [SerializeField] GameObject NPC;


    public void ButtonPressed()
    {
        NPC.SetActive(true);
    }
}

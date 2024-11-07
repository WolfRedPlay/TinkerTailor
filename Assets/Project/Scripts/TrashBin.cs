using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] AudioSource sound;

    [SerializeField] TMP_Text scoresText;

    int _scores;

    private void Start()
    {
        _scores = 0;
        scoresText.text = _scores.ToString();
        scoresText.gameObject.SetActive(false);

    }

    public void Hited()
    {
        _scores++;
        particles.Play();
        sound.Play();
        scoresText.text = _scores.ToString();
        scoresText.gameObject.SetActive(true);
        StartCoroutine(TimerToHide());
    }


    IEnumerator TimerToHide()
    {
        yield return new WaitForSeconds(2f);
        scoresText.gameObject.SetActive(false);
    }
}

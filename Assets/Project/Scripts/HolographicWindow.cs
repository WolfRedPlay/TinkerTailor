using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolographicWindow : MonoBehaviour
{
    [SerializeField] Transform spawnUIPoint;
    [SerializeField] GameObject window;
    [SerializeField] AudioSource openSound;
    [SerializeField] AudioSource closeSound;


    public void OpenWindow()
    {
        window.SetActive(true);
        transform.position = spawnUIPoint.position;
        openSound.Play();
    }

    public void CloseWindow()
    {
        window.SetActive(false);
        closeSound.Play();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleGenerator : MonoBehaviour
{
    [SerializeField] GameObject capsulePrefab;

    [SerializeField] Transform spawnPoint;

    [SerializeField] ChosenColorManager chosenColorManager;
    [SerializeField] AudioSource sound;


    public void GenerateCapsule()
    {
        if (chosenColorManager.ChosenColor != Color.clear)
        {
            GameObject newCapsule = Instantiate(capsulePrefab, spawnPoint.position, Quaternion.identity);
            newCapsule.GetComponent<PaintCapsule>().SetColor(chosenColorManager.ChosenColor);
            sound.Play();
        }

    }
}

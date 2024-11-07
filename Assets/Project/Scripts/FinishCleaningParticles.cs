using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCleaningParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem _bubbleParticles;
    [SerializeField] ParticleSystem _foamParticles;


    private void Update()
    {
        if (_bubbleParticles == null && _foamParticles == null)
        {
            Destroy(gameObject);
        }
    }
}

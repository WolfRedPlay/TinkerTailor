using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Removable : MonoBehaviour
{
    [SerializeField] float destroyDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrashBin"))
        {
            other.GetComponent<TrashBin>().Hited();
            StartCoroutine(StartTimer());
        }


    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TrashBin"))
        {
            StopAllCoroutines();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            StartCoroutine(StartTimer());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            StopAllCoroutines();
        }
    }


    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}

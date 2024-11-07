using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaning : MonoBehaviour
{
    Material baseDirtMaterial;
    
    Material _dirtMaterial;

    float _fadeSpeed = .5f;

    float _currentDirtAlpha;

    GameObject _dirtObject;

    Cleaner _sponge;

    public Action OnCleaningFinished;


    public void AssignMaterial(Material newMaterial)
    {
        baseDirtMaterial = newMaterial;
    }

    public void CreateDirtObject()
    {
        _dirtObject = new GameObject("Dirt");
        _dirtObject.transform.parent = transform;
        _dirtObject.transform.localPosition = Vector3.zero;
        _dirtObject.transform.rotation = gameObject.transform.rotation;
        _dirtObject.transform.localScale = Vector3.one;

        MeshFilter originalMeshFilter = GetComponent<MeshFilter>();


        MeshFilter dirtMeshFilter = _dirtObject.AddComponent<MeshFilter>();
        dirtMeshFilter.sharedMesh = originalMeshFilter.sharedMesh;

        MeshRenderer originalRenderer = GetComponent<MeshRenderer>();
        MeshRenderer dirtMeshRenderer = _dirtObject.AddComponent<MeshRenderer>();

        _dirtMaterial = new Material(baseDirtMaterial);
        
        dirtMeshRenderer.material = _dirtMaterial;
        
        _dirtMaterial.SetFloat("_DirtAlpha", 1);

        _currentDirtAlpha = 1;
    }




    private void FadeOut()
    {
        if (_currentDirtAlpha <= 0)
        {
            _sponge.StopCleaningSound();
            _sponge.FinishCleaning();
            Destroy(_dirtObject);

            OnCleaningFinished?.Invoke();
            OnCleaningFinished = null;

            Destroy(this);
            return;
        }

        _currentDirtAlpha -= _fadeSpeed * Time.deltaTime;

        _currentDirtAlpha = Mathf.Clamp01(_currentDirtAlpha);

        _dirtMaterial.SetFloat("_DirtAlpha", _currentDirtAlpha);


    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Sponge"))
        {
            if (_sponge != collision.gameObject.GetComponent<Cleaner>()) _sponge = collision.gameObject.GetComponent<Cleaner>();

            bool isMoving = _sponge.IsMoving;
           
            if (isMoving)
            {
                _sponge.PlayCleaningSound();
                FadeOut();
            }
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Sponge"))
        {
            collision.gameObject.GetComponent<Cleaner>().StopCleaningSound();
        }
    }
}

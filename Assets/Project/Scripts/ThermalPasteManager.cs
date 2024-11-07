using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ThermalPasteManager : MonoBehaviour
{
    [SerializeField] Material basePasteMaterial;

    Material _pasteMaterial;

    float _fadeSpeed = .5f;

    float _currentPasteAlpha;

    GameObject _pasteObject;

    Cleaner _cleaner;


    private void Start()
    {
        _currentPasteAlpha = 1;
        CreateDirtObject();
    }


    private void CreateDirtObject()
    {
        _pasteObject = new GameObject("Paste");
        _pasteObject.transform.parent = transform;
        _pasteObject.transform.localPosition = Vector3.zero;
        _pasteObject.transform.rotation = gameObject.transform.rotation;
        _pasteObject.transform.localScale = Vector3.one;

        MeshFilter originalMeshFilter = GetComponent<MeshFilter>();


        MeshFilter dirtMeshFilter = _pasteObject.AddComponent<MeshFilter>();
        dirtMeshFilter.sharedMesh = originalMeshFilter.sharedMesh;

        MeshRenderer originalRenderer = GetComponent<MeshRenderer>();
        MeshRenderer dirtMeshRenderer = _pasteObject.AddComponent<MeshRenderer>();

        _pasteMaterial = new Material(basePasteMaterial);

        dirtMeshRenderer.material = _pasteMaterial;

        _pasteMaterial.SetFloat("_DirtAlpha", _currentPasteAlpha);


    }




    private void FadeOut()
    {
        if (_currentPasteAlpha <= 0)
        {
            Destroy(_pasteObject);
            return;
        }

        _currentPasteAlpha -= _fadeSpeed * Time.deltaTime;

        _currentPasteAlpha = Mathf.Clamp01(_currentPasteAlpha);

        _pasteMaterial.SetFloat("_DirtAlpha", _currentPasteAlpha);


    }
    
    private void FadeIn()
    {
        if (_currentPasteAlpha <= 0)
        {
            CreateDirtObject();
        }

        if (_currentPasteAlpha != 1)
        {
            _currentPasteAlpha += _fadeSpeed * Time.deltaTime;

            _currentPasteAlpha = Mathf.Clamp01(_currentPasteAlpha);

            _pasteMaterial.SetFloat("_DirtAlpha", _currentPasteAlpha);
        }
        else
        {
            gameObject.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask("Default", "CPU");
            this.enabled = false;
        }




    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("ThermalPasteRemover"))
        {
            if (_cleaner != collision.gameObject.GetComponent<Cleaner>()) _cleaner = collision.gameObject.GetComponent<Cleaner>();

            bool isMoving = _cleaner.IsMoving;

            if (isMoving)
            {
                FadeOut();
            }
        }
        else if (collision.transform.CompareTag("PasteTube"))
        {
            FadeIn();
        }
    }
}

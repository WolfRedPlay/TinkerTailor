using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ColorButton : MonoBehaviour
{
    [SerializeField] Colors color;

    Color _color;


    Image _image;



    private void Start()
    {
        _color = ConstantColors.GetColor(color);

        _image = GetComponent<Image>();
        _image.color = _color;
    }


    public void OnButtonPressed()
    {
        ColorButtonPressedEvent evt = Events.ColorButtonPressedEvent;

        evt.ChosenColor = _color;

        EventManager.Broadcast(evt);
    }
}

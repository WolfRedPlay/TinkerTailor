using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveUIElement : MonoBehaviour
{
    [SerializeField] TMP_Text hintText;
    [SerializeField] Toggle checkBox;
    [SerializeField] Image checkBoxImage;

    public void SetHintText(string newHintText)
    {
        hintText.text = newHintText;
    }

    public void SetCheckBox(bool value)
    {
        checkBox.isOn = value;
        if (value)
        {
            checkBoxImage.color = Color.green;
            hintText.color = Color.green;
        }
        else 
        {
            checkBoxImage.color = Color.white;
            hintText.color = Color.white;
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Typing : MonoBehaviour
{

    [SerializeField] TMP_Text _textField;

    [SerializeField] float lettersDelay = .05f;



    Punctuation[] _punctuations = {

        new Punctuation( new HashSet<char> {',',  '-'}, .2f),
        new Punctuation( new HashSet<char> {'.'}, .5f),
        new Punctuation( new HashSet<char> {'!', '?', '…', ':'}, .9f),

    };

    private void Start()
    {
        _textField.text = string.Empty;
    }

    public Coroutine Run(string stringToShow)
    {
        _textField.text = string.Empty;
        return StartCoroutine(StartTyping(stringToShow));
    }



    IEnumerator StartTyping(string stringToShow)
    {
        int charIndex = 0;

        while (charIndex < stringToShow.Length)
        {
            int lastCharIndex = charIndex;

            charIndex++;

            for (int i = lastCharIndex; i < charIndex; i++)
            {
                bool isLast = i >= stringToShow.Length - 1;

                _textField.text = stringToShow.Substring(0, i + 1);


                if (IsPunctuation(stringToShow[i], out float waitTime) && !isLast && !IsPunctuation(stringToShow[i + 1], out _))
                {
                    
                     yield return new WaitForSeconds(waitTime);
                } 
                else yield return new WaitForSeconds(lettersDelay);
                
            }
        }
    }


    private bool IsPunctuation(char sign, out float waitTime)
    {
        foreach(var punct in _punctuations)
        {
            if (punct.Sign.Contains(sign))
            {
                waitTime = punct.WaitTime;
                return true;
            }
        }
        waitTime = lettersDelay;
        return false;
    }


    public void Clean()
    {
        _textField.text = string.Empty;
    }
}





struct Punctuation
{
    public HashSet<char> Sign;

    public float WaitTime;

    public Punctuation(HashSet<char> sing, float waitTime)
    {
        Sign = sing;
        WaitTime = waitTime;
    }
}

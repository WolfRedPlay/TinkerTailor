using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public static class Constants
{
}

public enum Colors
{
    BASIC_BLUE,
    BASIC_YELLOW,
    BASIC_WHITE,
    BASIC_RED,
    BASIC_BLACK,
    BASIC_GREY,
    CYBERPUNK_ELECTRIC,
    CYBERPUNK_PRUSSIAN,
    CYBERPUNK_AQUA,
    CYBERPUNK_LAVENDER,
    CYBERPUNK_NAVY,
    CYBERPUNK_TOXIC,

}


public static class ConstantColors
{
    static Color _pallet1Color1 = new Color(0.30f, 0.34f, 0.75f, 1);
    static Color _pallet1Color2 = new Color(0.86f, 0.71f, 0.24f, 1);
    static Color _pallet1Color3 = new Color(0.88f, 0.88f, 0.87f, 1);
    static Color _pallet1Color4 = new Color(0.63f, 0.2f, 0.13f, 1);
    static Color _pallet1Color5 = new Color(0.07f, 0.07f, 0.07f, 1);
    static Color _pallet1Color6 = new Color(0.48f, 0.48f, 0.48f, 1);
    
    static Color _pallet2Color1 = new Color(0.8f, 0.09f, 0.75f, 1);
    static Color _pallet2Color2 = new Color(0.25f, 0.24f, 0.97f, 1);
    static Color _pallet2Color3 = new Color(0.13f, 0.86f, 0.89f, 1);
    static Color _pallet2Color4 = new Color(0.74f, 0.74f, 0.02f, 1);
    static Color _pallet2Color5 = new Color(0.86f, 0.35f, 0.01f, 1);
    static Color _pallet2Color6 = new Color(0.09f, 0.92f, 0.08f, 1);
    
    static Color _pallet3Color1 = new Color(0.1921569f, 0.2156863f, 0.5607843f, 1);
    static Color _pallet3Color2 = new Color(0.8627451f, 0.7098039f, 0.2352941f, 1);
    static Color _pallet3Color3 = new Color(0.8784314f, 0.8784314f, 0.8745098f, 1);
    static Color _pallet3Color4 = new Color(0.6313726f, 0.2f, 0.1333333f, 1);
    static Color _pallet3Color5 = new Color(0.07058824f, 0.07058824f, 0.07058824f, 1);
    static Color _pallet3Color6 = new Color(0.7176471f, 0.7176471f, 0.7176471f, 1);

    public static Color GetColor(Colors color)
    {
        switch (color)
        {
            case Colors.BASIC_BLUE:
                return _pallet1Color1;

            case Colors.BASIC_YELLOW:
                return _pallet1Color2;
            
            case Colors.BASIC_WHITE:
                return _pallet1Color3;
            
            case Colors.BASIC_RED:
                return _pallet1Color4;
            
            case Colors.BASIC_BLACK:
                return _pallet1Color5;

            case Colors.BASIC_GREY:
                return _pallet1Color6;

            case Colors.CYBERPUNK_ELECTRIC:
                return _pallet2Color1;
            
            case Colors.CYBERPUNK_PRUSSIAN:
                return _pallet2Color2;

            case Colors.CYBERPUNK_AQUA:
                return _pallet2Color3;

            case Colors.CYBERPUNK_LAVENDER:
                return _pallet2Color4;

            case Colors.CYBERPUNK_NAVY:
                return _pallet2Color5;

            case Colors.CYBERPUNK_TOXIC:
                return _pallet2Color6;

            default:
                return Color.clear;
            
        }
    }



    public static Color CommonEmissionColor = new Color(0f, 0.6f, 1f, 1f);
    public static Color CorrectEmissionColor = new Color(0.02f, 0.3f, 0f, 1f);
    public static Color WrongEmissionColor = new Color(.6f, 0f, 0f, 1f);
}



public static class Speeds
{
    public const float BoltSpeed = 0.01f;

    public const float PaintSpeed = 1f; 
}

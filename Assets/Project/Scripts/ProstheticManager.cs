using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PartType
{
    ELBOW,
    EXTRA_FOREARM,
    EXTRA_SHOULDER,
    HAND,
    FOREARM,
    SHOULDER,
    UPPER_ARM,
    CPU_LID,
    BATTERY_LID,
    ENGINE_LID,
    ANY
}

public class ProstheticManager : MonoBehaviour
{
    [SerializeField] List<ProstheticPart> parts;

    public List<ProstheticPart> Parts => parts;

}





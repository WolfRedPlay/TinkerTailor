using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events 
{
    public static ColorButtonPressedEvent ColorButtonPressedEvent = new ColorButtonPressedEvent();
    public static SegmentConnectedEvent SegmentConnectedEvent = new SegmentConnectedEvent();
    public static SegmentDisconnectedEvent SegmentDetachedEvent = new SegmentDisconnectedEvent();
    public static DialogueStartedEvent DialogueStartedEvent = new DialogueStartedEvent();
    public static ReactionUsedEvent ReactionUsedEvent = new ReactionUsedEvent();
    public static PartCleanedEvent PartCleanedEvent = new PartCleanedEvent();
    public static ReplaceObjectiveFinishedEvent ReplaceObjectiveFinishedEvent = new ReplaceObjectiveFinishedEvent();
    public static ChangeColorObjectiveFinishedEvent ChangeColorObjectiveFinishedEvent = new ChangeColorObjectiveFinishedEvent();
    public static CleaningObjectiveFinishedEvent CleaningObjectiveFinishedEvent = new CleaningObjectiveFinishedEvent();
    public static OrderFinished OrderFinished = new OrderFinished();
}

public class ColorButtonPressedEvent : GameEvent
{
    public Color ChosenColor;
}

public class SegmentDisconnectedEvent: GameEvent
{
    public SegmentType SegmentType;
    public bool IsBroken;
}

public class SegmentConnectedEvent: GameEvent
{
    public SegmentType SegmentType;
    public bool IsBroken;
}

public class DialogueStartedEvent : GameEvent
{
    public string AnimationName;
    public AudioClip VoiceLine;
}

public class ReactionUsedEvent: GameEvent 
{
    public DialogueLineSO DialogueToStart;
}

public class PartColorChangedEvent: GameEvent
{
    public ProstheticPart ProstheticPart;
    public Color Color;
} 

public class PartCleanedEvent: GameEvent
{
    public PartType PartType;
}

public class ReplaceObjectiveFinishedEvent : GameEvent
{
    public SegmentType SegmentType;
}

public class ChangeColorObjectiveFinishedEvent : GameEvent
{
}

public class CleaningObjectiveFinishedEvent : GameEvent
{

}

public class OrderFinished: GameEvent
{

}


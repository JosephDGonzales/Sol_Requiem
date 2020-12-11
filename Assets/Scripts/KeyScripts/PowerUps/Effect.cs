using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Effect
{
    public float length;//length of powerup
    public UnityAction action;//first action
    public UnityAction endAction;//resetting the game to normal state

    //references
    public Effect(float length, UnityAction action, UnityAction endAction)
    {
        this.length = length;
        this.action = action;
        this.endAction = endAction;
    }
}

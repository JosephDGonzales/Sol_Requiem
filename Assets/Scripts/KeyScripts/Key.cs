using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;

    public bool blueHeld;
    public bool cyanHeld;
    public bool redHeld;
    public bool greenHeld;
    public bool orangeHeld;
    public bool purpleHeld;
    public bool yellowHeld;


    public enum KeyType
    {
        Blue,
        Cyan,
        Red,
        Green,
        Orange,
        Purple,
        Yellow
    }        

    private void Start()
    {
        blueHeld = false;
        cyanHeld = false;
        redHeld = false;
        greenHeld = false;
        orangeHeld = false;
        purpleHeld = false;
        yellowHeld = false;
    }
}
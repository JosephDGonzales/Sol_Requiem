using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeyHolder : MonoBehaviour
{


    public GameObject blueKey;
    public GameObject cyanKey;
    public GameObject redKey;
    public GameObject greenKey;
    public GameObject orangeKey;
    public GameObject purpleKey;
    public GameObject yellowKey;
    public Key getKeys;

    private void Start()
    {
        blueKey.SetActive(false);
        cyanKey.SetActive(false);
        redKey.SetActive(false);
        greenKey.SetActive(false);
        orangeKey.SetActive(false);
        purpleKey.SetActive(false);
        yellowKey.SetActive(false);

    }

    private void Update()
    {
        if (getKeys.blueHeld)
        {
            blueKey.SetActive(true);
        }
        else
        {
            blueKey.SetActive(false);
        }

        if (getKeys.cyanHeld)
        {
            cyanKey.SetActive(true);
        }
        else
        {
            cyanKey.SetActive(false);
        }

        if (getKeys.redHeld)
        {
            redKey.SetActive(true);
        }
        else
        {
            redKey.SetActive(false);
        }

        if (getKeys.greenHeld)
        {
            greenKey.SetActive(true);
        }
        else
        {
            greenKey.SetActive(false);
        }

        if (getKeys.orangeHeld)
        {
            orangeKey.SetActive(true);
        }
        else
        {
            orangeKey.SetActive(false);
        }

        if (getKeys.purpleHeld)
        {
            purpleKey.SetActive(true);
        }
        else
        {
            purpleKey.SetActive(false);
        }

        if (getKeys.yellowHeld)
        {
             yellowKey.SetActive(true);
        }
        else
        {
            yellowKey.SetActive(false);
        }
    }
}
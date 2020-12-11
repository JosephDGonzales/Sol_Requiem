using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Datapad : MonoBehaviour
{
    //define public variables
    public static bool isDatapadOpen = false;
    public GameObject DatapadUI;

    //Start is called before the first frame update
    private void Start()
    {
        DatapadUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DatapadUI.SetActive(true);
            isDatapadOpen = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DatapadUI.SetActive(false);
            isDatapadOpen = false;
        }
    }
}

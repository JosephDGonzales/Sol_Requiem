using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //define public variables
    public static bool isMenuPaused = false;
    public GameObject PauseUI;

    //Start is called before the first frame update
    private void Start()
    {
        PauseUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        } 
    }

    void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        isMenuPaused = true;
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        isMenuPaused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Debug.Log("Loading menu...");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
     public void QuitGame()
    {
        Debug.Log("Quittting Game!");
        Application.Quit();
    }
}

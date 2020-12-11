using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{

    public void PlayGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManagerMainMenu>().Play("Select");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void QuitGame()
    {
        Debug.Log("Ended The Game!");
        Application.Quit();
    }
}

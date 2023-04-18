using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public static bool GameIsDrunk = false;

    public GameObject resumeText;
    public GameObject pauseText;
    public GameObject muteText;
    public GameObject menuText;

    public GameObject pauseMenuUI;

    public GameObject drunkScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Options"))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void LoadMenu(){
        SceneManager.LoadScene(0);
        Resume();
    }

    public void DrunkMute(){
        
        if(!GameIsDrunk){
            drunkScreen.SetActive(true);
            resumeText.SetActive(false);
            pauseText.SetActive(false);
            muteText.SetActive(false);
            menuText.SetActive(false);
            GameIsDrunk = true;
        }
        else{
            drunkScreen.SetActive(false);
            resumeText.SetActive(true);
            pauseText.SetActive(true);
            muteText.SetActive(true);
            menuText.SetActive(true);
            GameIsDrunk = false;
        }
        
    }
}

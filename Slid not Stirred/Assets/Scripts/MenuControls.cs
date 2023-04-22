using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControls : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void LoadLSelect(){
        SceneManager.LoadScene(5);
    }
    public void LoadMenu(){
        SceneManager.LoadScene(0);
    }
     public void LoadLevel(){
        SceneManager.LoadScene(1);
    }
    public void LoadLevel2(){
        SceneManager.LoadScene(2);
    }
    public void LoadLevel3(){
        SceneManager.LoadScene(3);
    }
    public void LoadLevel4(){
        SceneManager.LoadScene(4);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

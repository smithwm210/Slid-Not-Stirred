using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    private int score = 0;

    private void Awake() {
      DontDestroyOnLoad(this);
    }
    public void Restart(){
     
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     if(score < 3){
      score++;
     }
     else if(score >= 3){
      score = 0;
     }
     Debug.Log(score);

   }
}

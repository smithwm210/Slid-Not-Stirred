using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    public int score = 0;
    public static GameManager instance;
    private void Awake() {
       if (instance == null)
            instance = this;
        else{

            Destroy(gameObject);
            return;
        }

        


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

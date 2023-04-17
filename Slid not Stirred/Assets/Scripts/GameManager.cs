using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    private float defaultPositionX, defaultPositionY;
    public int round = 1;

    public int wins = 0;
    public int losses = 0;
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
      if(round < 3){
        round++;
       
      }
      else if(round >= 3){
        round = 1;
        EndGame();
      }
      Debug.Log(round);
    }
   public void Win(){
    wins++;
   }

   public void Lose(){
    losses++;
   }

   public void EndGame(){
    wins = 0;
    losses = 0;
   }
}

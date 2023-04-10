using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownController : MonoBehaviour
{
    public int countDownTimer;
    public TextMeshProUGUI timerDis;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountDown());
    }

    
   IEnumerator StartCountDown(){

        while(countDownTimer > 0){


            if(countDownTimer == 3){
                timerDis.text = "Ready!";
            }

            if(countDownTimer == 2){
                timerDis.text = "Set!";
            }
            
            if(countDownTimer == 1){
                timerDis.text = "Go!";
            }

            yield return new WaitForSeconds(0.75f);

            countDownTimer--;

        }

        FindObjectOfType<PlayerController2>().enabled = true;
        timerDis.gameObject.SetActive(false);
   }
}

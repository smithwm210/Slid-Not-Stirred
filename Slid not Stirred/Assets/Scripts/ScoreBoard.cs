using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI curRound;
    public TextMeshProUGUI curWins;
    public TextMeshProUGUI curLosses;

    public GameObject endingAnimation;

    // Update is called once per frame
    void Update()
    {
        curRound.text = "Round: " + SceneManager.GetActiveScene().buildIndex;
        //curWins.text = "Wins: " +  FindObjectOfType<GameManager>().wins.ToString();
        //curLosses.text = "Losses: " +  FindObjectOfType<GameManager>().losses.ToString();
    }
}

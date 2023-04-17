using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI curRound;
    public TextMeshProUGUI curWins;
    public TextMeshProUGUI curLosses;

    // Update is called once per frame
    void Update()
    {
        curRound.text = "Round: " + FindObjectOfType<GameManager>().round.ToString();
        curWins.text = "Wins: " +  FindObjectOfType<GameManager>().wins.ToString();
        curLosses.text = "Losses: " +  FindObjectOfType<GameManager>().losses.ToString();
    }
}

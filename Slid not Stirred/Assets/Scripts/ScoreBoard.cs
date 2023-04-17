using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI curScore;

    // Update is called once per frame
    void Update()
    {
        curScore.text = "Round: " + FindObjectOfType<GameManager>().round.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
        public Text scoreBoard1;
        public Text scoreBoard2;
        public Text scoreBoard3;
        public Text scoreBoard4;
        public CarryOver source;

    void start()
    {
        source = FindObjectOfType<CarryOver>();
    }

    void Update()
    {
        scoreboard1.text = source.score1.tostring();
        scoreboard2.text = source.score2.tostring();
        scoreboard3.text = source.score3.tostring();
        scoreboard4.text = source.score4.tostring();

    } 
    
    
}

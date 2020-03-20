using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public float score1;
    public Text scoreUI1;
    public float score2;
    public Text scoreUI2;
    public float score3;
    public Text scoreUI3;
    public float score4;
    public Text scoreUI4;

    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
        scoreUI1.text = "score1";
    }
}

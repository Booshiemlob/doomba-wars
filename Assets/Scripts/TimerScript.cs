using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float time;
    public TMP_Text timeUI;
    // Start is called before the first frame update
    void Update()
    {
        timeUI.text = "Time Remaining: " + Convert.ToInt32(time);
        time -= 1 * Time.deltaTime;
        if(time <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }
}

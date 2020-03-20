using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {

        }
    }
}

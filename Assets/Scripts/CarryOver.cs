using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryOver : MonoBehaviour
{
public float score1;
public float score2;
public float score3;
public float score4;

   
    void Awake()
    {
        
        DontDestroyOnLoad (transform.gameObject);
    }
}

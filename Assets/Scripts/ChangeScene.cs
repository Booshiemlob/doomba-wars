using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ChangeScene : MonoBehaviour
{

    //changes the scene with a press of a button
    public void ChangeToScene(int ChangeTheScene)
    {
        SceneManager.LoadScene(ChangeTheScene);
    }
}
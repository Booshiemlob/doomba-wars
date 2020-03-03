using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    //changes the scene with a press of a button
    public void ChangeToScene(int ChangeTheScene)
    {
        SceneManager.LoadScene(ChangeTheScene);
    }
}
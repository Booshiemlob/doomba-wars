using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class controllerinputtester : MonoBehaviour
{
    public TMP_Text DebugText;
    public float hAxis;
    public float vAxis;
    public float htAxis;
    public float vtAxis;

    void ControllerCheck()
    {
        float ltaxis = Input.GetAxis("TriggerL");
        float rtaxis = Input.GetAxis("TriggerR");
        float dhaxis = Input.GetAxis("DpadHorizontal");
        float dvaxis = Input.GetAxis("DpadVertical");

        bool xbox_a = Input.GetButton("A");
        bool xbox_b = Input.GetButton("B");
        bool xbox_x = Input.GetButton("X");
        bool xbox_y = Input.GetButton("Y");
        bool xbox_lb = Input.GetButton("Left Bumper");
        bool xbox_rb = Input.GetButton("Right Bumper");
        bool xbox_ls = Input.GetButton("Left Stick Button");
        bool xbox_rs = Input.GetButton("Right Stick Button");
        bool xbox_view = Input.GetButton("View");
        bool xbox_menu = Input.GetButton("Menu");

        DebugText.text =
            string.Format(
                "Horizontal: {14:0.000} Vertical: {15:0.000}\n" +
                "HorizontalTurn: {16:0.000} VerticalTurn: {17:0.000}\n" +
                "LTrigger: {0:0.000} RTrigger: {1:0.000}\n" +
                "A: {2} B: {3} X: {4} Y:{5}\n" +
                "LB: {6} RB: {7} LS: {8} RS:{9}\n" +
                "View: {10} Menu: {11}\n" +
                "Dpad-H: {12:0.000} Dpad-V: {13:0.000}\n",
                ltaxis, rtaxis,
                xbox_a, xbox_b, xbox_x, xbox_y,
                xbox_lb, xbox_rb, xbox_ls, xbox_rs,
                xbox_view, xbox_menu,
                dhaxis, dvaxis,
                hAxis, vAxis,
                htAxis, vtAxis);
    }

    void Start()
    {
       
    }
    void Update()
    {
        //Get Joystick Names
        string[] temp = Input.GetJoystickNames();

        //Check whether array contains anything
        if (temp.Length > 0)
        {
            //Iterate over every element
            for (int i = 0; i < temp.Length; ++i)
            {
                //Check if the string is empty or not
                if (!string.IsNullOrEmpty(temp[i]))
                {
                    //Not empty, controller temp[i] is connected
                    Debug.Log("Controller " + i + " is connected using: " + temp[i]);
                }
                else
                {
                    //If it is empty, controller i is disconnected
                    //where i indicates the controller number
                    Debug.Log("Controller: " + i + " is disconnected.");

                }
            }
        }
        // Camera Rig Movement Control
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        htAxis = Input.GetAxis("HorizontalTurn");
        vtAxis = Input.GetAxis("VerticalTurn");

        ControllerCheck();
}
}

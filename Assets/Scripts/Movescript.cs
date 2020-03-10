using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movescript : MonoBehaviour
{
    GameObject Roomba1;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotateSpeed = 3.0f;
    private Rigidbody rb;
    private Transform transformMove;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        Roomba1 = this.gameObject;
    }

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;
        this.transform.position += moveDirection;
       // Debug.Log(Input.GetAxis("Horizontal"));

        //Rotate Player
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
    }
}

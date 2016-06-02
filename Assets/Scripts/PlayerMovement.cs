using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float moveSpeed; //How fast to move.
    [SerializeField]
    private KeyCode Left; //Key to move left.
    [SerializeField]
    private KeyCode Right; //Key to move right.
    [SerializeField]
    private KeyCode Down; //Key to move down.
    [SerializeField]
    private KeyCode Up; //Key to move up.


    private Vector3 direction; //Direction.
    private Vector3 moveDirection; //Direction * Movespeed.


    public float minX = -360.0f;
    public float maxX = 360.0f;

    public float sensX = 100.0f;

    float rotationX = 0.0f;
    

    void Update() {
        PlayerInput();

        rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotationX, 0);
    }

    void PlayerInput() {
        direction = new Vector3(0, 0, 0);
        if (Input.GetKey(Left)) { direction -= transform.right; }
        if (Input.GetKey(Right)) { direction += transform.right; }
        if (Input.GetKey(Down)) { direction -= transform.forward; }
        if (Input.GetKey(Up)) { direction += transform.forward; }

        moveDirection = direction * moveSpeed * Time.deltaTime; //Smooth Movement.
        transform.position += moveDirection; //Apply movement.

    }
}

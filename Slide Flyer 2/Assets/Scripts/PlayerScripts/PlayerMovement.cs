using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private Joystick joystick;
    [SerializeField] private float movementSpeed;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    private Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {

        horizontalMove = joystick.Horizontal * movementSpeed;
        verticalMove = joystick.Vertical * movementSpeed;

    }

    void FixedUpdate() {
        rb.velocity = new Vector2(horizontalMove, verticalMove);
    }

}

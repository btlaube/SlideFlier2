using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour {
    
    public ObstacleObject obstacleObject;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start() {
        sr.sprite = obstacleObject.sprite;
    }

    void FixedUpdate() {
        Movement();
    }

    private void Movement() {
        rb.velocity = transform.up * -obstacleObject.speed.value;
    }

}

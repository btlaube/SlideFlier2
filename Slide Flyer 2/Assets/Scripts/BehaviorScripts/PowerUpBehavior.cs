using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour {
    
    public PowerUpObject powerUpObject;

    [SerializeField] private PlayerStats playerStats;
    private Rigidbody2D rb;
    private SpriteRenderer sr;


    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start() {
        sr.sprite = powerUpObject.sprite;
        rb.velocity = transform.up * -powerUpObject.speed.value;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.tag == "Player") {
            //Add Power Up to power up manager
            PowerUpManager.instance.Add(powerUpObject);
            Destroy(gameObject);
        }
    }

}

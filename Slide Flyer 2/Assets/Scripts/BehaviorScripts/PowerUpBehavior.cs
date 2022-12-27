using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour {
    
    public PowerUpObject powerUpObject;

    [SerializeField] private PlayerStats playerStats;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    //Add power up to display
    [SerializeField] private PowerUpCanvasScript powerUpCanvas;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        powerUpCanvas = GameObject.Find("Power Up Canvas").GetComponent<PowerUpCanvasScript>();
    }

    void Start() {
        sr.sprite = powerUpObject.sprite;
        rb.velocity = transform.up * -powerUpObject.speed.value;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        //When this pick up object collides with the player
            //Activate this pickup
            //Delete this pick up
        if (hitInfo.tag == "Player") {
            //Add Power Up Slot to Power Up Grid in Power Up Canvas
            PowerUpManager.instance.Add(powerUpObject);
            Destroy(gameObject);
        }
    }

}

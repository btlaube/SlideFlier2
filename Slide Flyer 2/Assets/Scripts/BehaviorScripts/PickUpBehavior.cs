using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehavior : MonoBehaviour {

    public PickUpObject pickUpObject;

    [SerializeField] private PlayerStats playerStats;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    private ObjectAudioSource audioSource;

    private bool attracted;
    private Transform attractedTarget;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<ObjectAudioSource>();
    }

    void Start() {
        sr.sprite = pickUpObject.sprite;
        rb.velocity = transform.up * -pickUpObject.speed.value;
    }

    void FixedUpdate() {
        if (attracted) {
            MoveToward();
        }
    }

    void MoveToward() {
        Vector2 targetPosition = attractedTarget.transform.position;
        Vector2 currentPosition = transform.position;
        Vector3 directionOfTravel = targetPosition - currentPosition;

        this.transform.Translate((directionOfTravel.x * (pickUpObject.speed.value*2) * Time.deltaTime),
                (directionOfTravel.y * (pickUpObject.speed.value*2) * Time.deltaTime),
                (directionOfTravel.z * (pickUpObject.speed.value*2) * Time.deltaTime),
                Space.World);
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        //When this pick up object collides with the player
            //Activate this pickup
            //Delete this pick up
        if (hitInfo.tag == "PlayerAttractArea") {
            attracted = true;
            attractedTarget = hitInfo.transform;
        }
        else if (hitInfo.tag == "PlayerCollectArea") {
            audioSource.Play(pickUpObject.pickUpSound);
            
            Ability();
            sr.enabled = false;
            bc.enabled = false;
            Invoke("DestroySelf", 1f);
        }
    }

    void Ability() {
        //TODO change hardcoded values
        switch(pickUpObject.ability) {
            case "Ammo":
                playerStats.playerCurrentAmmo.value = Mathf.Clamp(playerStats.playerCurrentAmmo.value + 20, 0, playerStats.playerMaxAmmo.value);
                break;
            case "Health":
                playerStats.playerCurrentHealth.value = Mathf.Clamp(playerStats.playerCurrentHealth.value + 1, 0, playerStats.playerMaxHealth.value);
                break;
            case "Fuel":
                playerStats.playerCurrentFuel.value = Mathf.Clamp(playerStats.playerCurrentFuel.value + 20, 0, playerStats.playerMaxFuel.value);
                break;

        }
    }

    void DestroySelf() {
        Destroy(gameObject);
    }
}

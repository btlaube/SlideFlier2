using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour {
    
    public PowerUpObject powerUpObject;

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
        sr.sprite = powerUpObject.sprite;
        rb.velocity = transform.up * -powerUpObject.speed.value;
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

        this.transform.Translate((directionOfTravel.x * (powerUpObject.speed.value*2) * Time.deltaTime),
                (directionOfTravel.y * (powerUpObject.speed.value*2) * Time.deltaTime),
                (directionOfTravel.z * (powerUpObject.speed.value*2) * Time.deltaTime),
                Space.World);
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.tag == "PlayerAttractArea") {
            attracted = true;
            attractedTarget = hitInfo.transform;
        }
        else if (hitInfo.tag == "PlayerCollectArea") {
            audioSource.Play("Collect");

            //Add Power Up to power up manager
            PowerUpManager.instance.Add(powerUpObject);

            sr.enabled = false;
            bc.enabled = false;
            Invoke("DestroySelf", 1f);
        }
    }

    void DestroySelf() {
        Destroy(gameObject);
    }
}

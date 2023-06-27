using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakEffectBehavior : MonoBehaviour {

    [SerializeField] private Vector2 forceDirection;
    [SerializeField] private float torque;
    private Rigidbody2D rb;
    private float timer = 0f;
    private float shrinkSpeed;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        rb.AddForce(forceDirection);
        rb.AddTorque(torque);

        shrinkSpeed = Random.Range(0.5f, 1.5f);
        Invoke("DestroySelf", shrinkSpeed);
    }

    void Update() {
        timer += Time.deltaTime;
        float newScale = Mathf.Lerp(0.7f, 0, timer/shrinkSpeed);
        transform.localScale = new Vector3(newScale, newScale, 1);
    }

    void DestroySelf() {
        Destroy(gameObject);
    }

}

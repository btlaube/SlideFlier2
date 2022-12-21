using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableScript : MonoBehaviour {
    
 
    private static float speed = 1f;
    private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
    }

}

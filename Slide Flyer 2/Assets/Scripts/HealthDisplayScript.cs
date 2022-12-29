using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplayScript : MonoBehaviour {
    
    public Sprite[] sprites;

    private SpriteRenderer sr;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update() {
        
    }

}

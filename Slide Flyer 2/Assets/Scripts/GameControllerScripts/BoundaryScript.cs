using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D hitInfo) {
        Destroy(hitInfo.gameObject);
    }

}

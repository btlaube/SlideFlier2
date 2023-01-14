using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakEffectParent : MonoBehaviour {
    void Start() {
        Invoke("DestroySelf", 1.5f);
    }

    void DestroySelf() {
        Destroy(gameObject);
    }

}

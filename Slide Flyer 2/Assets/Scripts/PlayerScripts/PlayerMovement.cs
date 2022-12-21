using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    void Update() {
        if (Input.touchCount > 0 ) {

            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touchPosition.y < -2.5) {

                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;
                touchPosition.y = -2.5f;
                transform.position = touchPosition;
            }            
        }        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewPlayerMovement : MonoBehaviour {
    
    private Vector2 startPos;
    private bool fingerDown = false;
    private Vector3 playerStartPos;

    void Update() {
        if (fingerDown == false && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            startPos = touchPosition;
            fingerDown = true;

            playerStartPos = transform.position;
        }
    }

    void FixedUpdate() {
        if (fingerDown) {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            Vector3 distanceMoved = new Vector3(startPos.x - touchPosition.x, startPos.y - touchPosition.y, 0f);

            transform.position = playerStartPos - (distanceMoved * 2);

            if (Input.GetTouch(0).phase == TouchPhase.Ended) {
                fingerDown = false;
            }
        }
    }
}

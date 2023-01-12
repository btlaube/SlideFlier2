using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    
    private Vector2 startPos;
    private bool fingerDown = false;
    private Vector3 playerStartPos;

    void Update() {
        if (fingerDown == false && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            Touch touch = Input.GetTouch(0);

            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId)) {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                startPos = touchPosition;
                fingerDown = true;

                playerStartPos = transform.position;
            }
        }
    }

    void FixedUpdate() {
        if (fingerDown && Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            Vector3 distanceMoved = new Vector3(startPos.x - touchPosition.x, startPos.y - touchPosition.y, 0f);

            //transform.position = playerStartPos - (distanceMoved * 2);

            //Vector3 nextPos = playerStartPos - (distanceMoved * 2);

            //Debug.Log($"{touch.position} {touchPosition} ({Screen.width}, {Screen.height}) {Camera.main.WorldToScreenPoint(playerStartPos - (distanceMoved * 2))}");

            //Testing screen boundaries
            if (Camera.main.WorldToScreenPoint(playerStartPos - (distanceMoved * 2)).x < 0 || Camera.main.WorldToScreenPoint(playerStartPos - (distanceMoved * 2)).x > Screen.width) {
                Debug.Log("out of bounds x");
                distanceMoved.x = 0f;
            }
            else if (Camera.main.WorldToScreenPoint(playerStartPos - (distanceMoved * 2)).y < 0 || Camera.main.WorldToScreenPoint(playerStartPos - (distanceMoved * 2)).y > Screen.height){
                Debug.Log("out of bounds y");
                distanceMoved.y= 0f;
            }

            transform.position = playerStartPos - (distanceMoved * 2);

            if (Input.GetTouch(0).phase == TouchPhase.Ended) {
                fingerDown = false;
            }
        }
    }
}

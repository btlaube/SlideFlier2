using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    
    private Vector2 startPos;
    [SerializeField] private bool fingerDown = false;
    private Vector3 playerStartPos;

    //Testing
    private Vector3 distanceMoved;
    private float worldScreenHeight;
    private float worldScreenWidth;
    private int movementTouch;

    void Start() {
        worldScreenHeight = Camera.main.orthographicSize * 2;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
    }

    void Update() {

        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId)) {
                    movementTouch = touch.fingerId;
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    startPos = touchPosition;

                    playerStartPos = transform.position;
                }
            }
            else if (touch.phase == TouchPhase.Ended && touch.fingerId == movementTouch) {
                movementTouch = 99;
            }
        }

        //if (fingerDown == false && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
        //    Touch touch = Input.GetTouch(0);
//
        //    if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId)) {
        //        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //        startPos = touchPosition;
        //        fingerDown = true;
//
        //        playerStartPos = transform.position;
        //    }
        //}
    }

    void FixedUpdate() {

        foreach (Touch touch in Input.touches) {
            if(touch.phase == TouchPhase.Moved && touch.fingerId == movementTouch) {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                Vector2 distanceMoved = touchPosition - startPos;

                transform.position = new Vector3(Mathf.Clamp(playerStartPos.x + (distanceMoved.x * 2), -(worldScreenWidth/2), (worldScreenWidth/2)), 
                                                Mathf.Clamp(playerStartPos.y + (distanceMoved.y * 2), -(worldScreenHeight/2), (worldScreenHeight/2)),
                                                0f);
            }
        }

        //if (fingerDown && Input.touchCount > 0) {
        //    //Touch touch = Input.GetTouch(0);
        //    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(movementTouch.position);
//
        //    Vector3 distanceMoved = new Vector3(startPos.x - touchPosition.x, startPos.y - touchPosition.y, 0f);
//
        //    //Vector3 distanceMoved = new Vector3(Mathf.Clamp(startPos.x - touchPosition.x, (playerStartPos.x-(worldScreenWidth/2))/2, (playerStartPos.x+(worldScreenWidth/2))/2),
        //    //                                    Mathf.Clamp(startPos.y - touchPosition.y, (playerStartPos.y-(worldScreenHeight/2))/2, (playerStartPos.y+(worldScreenHeight/2))/2),
        //    //                                    0f);
//
        //    transform.position = new Vector3(Mathf.Clamp(playerStartPos.x - (distanceMoved.x * 2), -(worldScreenWidth/2), (worldScreenWidth/2)), 
        //                                    Mathf.Clamp(playerStartPos.y - (distanceMoved.y * 2), -(worldScreenHeight/2), (worldScreenHeight/2)),
        //                                    0f);
//
        //    if (movementTouch.phase == TouchPhase.Ended) {
        //        fingerDown = false;
        //    }
        //}
    }
}
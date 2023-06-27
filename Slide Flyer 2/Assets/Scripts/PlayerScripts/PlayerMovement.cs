using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    
    private Vector2 startPos;
    private Vector3 playerStartPos;

    private float worldScreenHeight;
    private float worldScreenWidth;
    private int movementTouchId;

    [SerializeField] private PreferencesData preferencesData;

    void Start() {
        worldScreenHeight = Camera.main.orthographicSize * 2;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
    }

    void Update() {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId)) {
                    movementTouchId = touch.fingerId;
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    startPos = touchPosition;

                    playerStartPos = transform.position;
                }
            }
            else if (touch.phase == TouchPhase.Ended && touch.fingerId == movementTouchId) {
                movementTouchId = 99;
            }
        }
    }

    void FixedUpdate() {
        foreach (Touch touch in Input.touches) {
            if(touch.phase == TouchPhase.Moved && touch.fingerId == movementTouchId) {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                Vector2 distanceMoved = touchPosition - startPos;
                Vector3 previousPos = transform.position;

                transform.position = new Vector3(Mathf.Clamp(playerStartPos.x + (distanceMoved.x * preferencesData.movementSensitivity), -(worldScreenWidth/2), (worldScreenWidth/2)), 
                                                Mathf.Clamp(playerStartPos.y + (distanceMoved.y * preferencesData.movementSensitivity), -(worldScreenHeight/2), (worldScreenHeight/2)),
                                                0f);
            }
        }
    }
}
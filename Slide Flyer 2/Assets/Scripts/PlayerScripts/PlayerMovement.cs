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
    private int movementTouchId = -1;
    private bool isDragging = false;

    [SerializeField] private PreferencesData preferencesData;

    void Start() {
        worldScreenHeight = Camera.main.orthographicSize * 2;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
    }

    void Update() {
        HandleTouchInput();
        HandleMouseInput();
    }

    void HandleTouchInput() {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId)) {
                    movementTouchId = touch.fingerId;
                    startPos = Camera.main.ScreenToWorldPoint(touch.position);
                    playerStartPos = transform.position;
                }
            }
            else if (touch.phase == TouchPhase.Ended && touch.fingerId == movementTouchId) {
                movementTouchId = -1;
            }
        }
    }

    void HandleMouseInput() {
        if (Input.GetMouseButtonDown(0)) {
            if (!EventSystem.current.IsPointerOverGameObject()) {
                isDragging = true;
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                playerStartPos = transform.position;
            }
        }
        else if (Input.GetMouseButtonUp(0)) {
            isDragging = false;
        }
    }

    void FixedUpdate() {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Moved && touch.fingerId == movementTouchId) {
                MovePlayer(Camera.main.ScreenToWorldPoint(touch.position));
            }
        }

        if (isDragging && Input.GetMouseButton(0)) {
            MovePlayer(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    void MovePlayer(Vector2 inputPosition) {
        Vector2 distanceMoved = inputPosition - startPos;
        transform.position = new Vector3(
            Mathf.Clamp(playerStartPos.x + (distanceMoved.x * preferencesData.movementSensitivity), -(worldScreenWidth / 2), (worldScreenWidth / 2)),
            Mathf.Clamp(playerStartPos.y + (distanceMoved.y * preferencesData.movementSensitivity), -(worldScreenHeight / 2), (worldScreenHeight / 2)),
            0f
        );
    }
}
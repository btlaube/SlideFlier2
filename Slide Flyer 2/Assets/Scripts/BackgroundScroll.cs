using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    [SerializeField] private Sprite[] groundSprites;
    [SerializeField] private float backgroundSpeed;
    private int spriteIndex;

    //Variables
    [SerializeField] private float bottomBarrier;
    [SerializeField] private float topBarrier;
    [SerializeField] private float translationAmount;

    void Start() {
        foreach (Transform child in transform) {
            child.GetComponent<Rigidbody2D>().velocity = transform.up * -backgroundSpeed;
        }
        translationAmount = transform.GetChild(0).GetComponent<SpriteRenderer>().size.y * 2f;
        transform.GetChild(0).position = new Vector2(0f, translationAmount/2f);
        spriteIndex = 0;
    }

    void Update() {
        foreach (Transform child in transform) {
            if (child.position.y <= bottomBarrier) {
                child.position += new Vector3(0f, translationAmount, 0f);
                child.GetComponent<SpriteRenderer>().sprite = groundSprites[spriteIndex];
                spriteIndex++;
                if (spriteIndex > 2) {
                    spriteIndex = 0;
                }
            }
        }
    }

}

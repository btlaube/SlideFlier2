using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour {

    [SerializeField] private RawImage image;
    [SerializeField] private float speed;

    void Update() {
        image.uvRect = new Rect(image.uvRect.position + new Vector2(0f, speed) * Time.deltaTime, image.uvRect.size);
    }

}

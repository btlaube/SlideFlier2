using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupScript : MonoBehaviour {
    
    public static CanvasGroupScript instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void LoadGameScene() {
        foreach(Transform canvas in transform) {
            canvas.gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(true);
    }

}

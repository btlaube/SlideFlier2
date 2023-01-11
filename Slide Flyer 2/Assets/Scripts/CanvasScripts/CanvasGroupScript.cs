using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupScript : MonoBehaviour {
    
    public void LoadScene(int sceneToLoad) {
        SceneLoaderScript.instance.LoadScene(sceneToLoad);
    }

    public void Pause() {
        Time.timeScale = 0f;
        transform.GetChild(4).gameObject.SetActive(true);
    }

    public void Resume() {
        Time.timeScale = 1f;
        transform.GetChild(4).gameObject.SetActive(false);
    }

    public void Lose() {
        Time.timeScale = 0f;
        transform.GetChild(5).gameObject.SetActive(true);
    }
}

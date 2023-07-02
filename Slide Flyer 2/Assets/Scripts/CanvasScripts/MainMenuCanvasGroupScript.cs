using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvasGroupScript : MonoBehaviour {

    void Start() {
        OpenOptionsCanvas();
        CloseOptionsCanvas();
    }

    public void LoadScene(int sceneToLoad) {
        SceneLoaderScript.instance.LoadScene(sceneToLoad);
    }

    public void OpenInfoCanvas() {
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(true);
    }

    public void CloseInfoCanvas() {
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(false);
    }

    public void OpenShopCanvas() {
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
    }

    public void CloseShopCanvas() {
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(false);
    }

    public void OpenOptionsCanvas() {
        transform.GetChild(5).gameObject.SetActive(true);
    }

    public void CloseOptionsCanvas() {
        transform.GetChild(5).gameObject.SetActive(false);
    }

    public void ButtonClick() {
        AudioManager.instance.Play("ButtonClick");
    }
}

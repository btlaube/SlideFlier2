using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvasGroupScript : MonoBehaviour {

    public void LoadScene(int sceneToLoad) {
        SceneLoaderScript.instance.LoadScene(sceneToLoad);
    }

    public void OpenInfoCanvas() {
        transform.GetChild(4).gameObject.SetActive(true);
    }

    public void CloseInfoCanvas() {
        transform.GetChild(4).gameObject.SetActive(false);
    }

    public void OpenShopCanvas() {
        transform.GetChild(3).gameObject.SetActive(true);
    }

    public void CloseShopCanvas() {
        transform.GetChild(3).gameObject.SetActive(false);
    }

    public void OpenOptionsCanvas() {
        transform.GetChild(5).gameObject.SetActive(true);
    }

    public void CloseOptionsCanvas() {
        transform.GetChild(5).gameObject.SetActive(false);
    }
}

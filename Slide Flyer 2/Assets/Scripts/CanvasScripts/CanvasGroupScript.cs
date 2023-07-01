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
        ResumeTime();
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
    }

    public void Lose() {
        StopTime();
        transform.GetChild(5).gameObject.SetActive(true);
    }

    public void Continue()
    {
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
        Invoke("ResumeTime", 3.0f);
    }

    public void ShowOptionsMenu() {
        transform.GetChild(6).gameObject.SetActive(true);
    }

    public void CloseOptionsMenu() {
        transform.GetChild(6).gameObject.SetActive(false);
    }

    public void ButtonClick() {
        AudioManager.instance.Play("ButtonClick");
    }

    private void StopTime()
    {
        Time.timeScale = 0f;
    }

    private void ResumeTime()
    {
        Time.timeScale = 1f;
    }

}

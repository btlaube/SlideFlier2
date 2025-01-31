using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupScript : MonoBehaviour {
    
    public TimeManager timeManager;

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
        // StopTime();
        //DisableObjects();
        DisableObjectsCaller();
        transform.GetChild(5).gameObject.SetActive(true);
    }

    public void Continue()
    {
        // EnableObjects();
        Invoke("EnableObjectsTimer", 3.0f);
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
    }

    public void DisableObjectsCaller()
    {
        timeManager.DisableObjects();
    }

    public void EnableObjectsTimer()
    {
        timeManager.EnableObjects();
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

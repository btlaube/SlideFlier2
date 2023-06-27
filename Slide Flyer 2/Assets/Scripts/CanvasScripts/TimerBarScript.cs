using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBarScript : MonoBehaviour {
    
    [SerializeField] private float totalTime;
    [SerializeField] private float timer;
    [SerializeField] private Image totalTimerBar;
    [SerializeField] private Image currentTimerBar;

    void Start() {
        timer = Time.deltaTime + totalTime;
    }

    void Update() {
        timer -= Time.deltaTime;
        currentTimerBar.fillAmount = timer / totalTime;
    }


}

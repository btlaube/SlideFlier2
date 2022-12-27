using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpSlotBehavior : MonoBehaviour {
    
    public PowerUpObject powerUpObject;
    [SerializeField] private Image icon;
    private GameObject player;

    public int powerUpCount;
    [SerializeField] private TMP_Text countText;

    public float totalTime;
    public float timer;
    [SerializeField] private Image totalTimerBar;
    [SerializeField] private Image currentTimerBar;

    void Start() {
        totalTime = powerUpObject.duration;
        player = GameObject.Find("Player");
        icon.sprite = powerUpObject.sprite;
        powerUpObject.Activate(player);

        timer = Time.deltaTime + totalTime;

        powerUpCount = 1;
        countText.text = $"x{powerUpCount}";
    }

    void Update() {
        countText.text = $"x{powerUpCount}";
        timer -= Time.deltaTime;
        currentTimerBar.fillAmount = timer / totalTime;
        if (timer <= 0f) {
            powerUpObject.Deactivate();
            Destroy(gameObject);
        }
    }


}

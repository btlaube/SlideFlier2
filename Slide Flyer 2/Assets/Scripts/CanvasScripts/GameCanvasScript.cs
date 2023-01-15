using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCanvasScript : MonoBehaviour {
    
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PreferencesData preferencesData;

    [SerializeField] private TMP_Text playerScoreText;
    [SerializeField] private TMP_Text playerHighscoreText;
    [SerializeField] private TMP_Text playerCoinsText;

    //Testing Fill Bars
    [SerializeField] private Image healthfillBar;
    [SerializeField] private Image fuelFillBar;
    [SerializeField] private Image ammoFillBar;

    [SerializeField] private RectTransform fireButton;
    
    void Start() {
        UpdateFireButtonLayout();
    }

    void Update() {
        playerScoreText.text = $"{playerStats.playerScore.value}";
        playerHighscoreText.text = $"{playerStats.playerHighscore.value}";
        playerCoinsText.text = $"{playerStats.playerCoins.value}";

        //Testing Fill Bars
        healthfillBar.fillAmount = (float)(playerStats.playerCurrentHealth.value)/(float)(playerStats.playerMaxHealth.value);
        fuelFillBar.fillAmount = (float)(playerStats.playerCurrentFuel.value)/(float)(playerStats.playerMaxFuel.value);
        ammoFillBar.fillAmount = (float)(playerStats.playerCurrentAmmo.value)/(float)(playerStats.playerMaxAmmo.value);
    }

    public void UpdateFireButtonLayout() {
        if (preferencesData.fireButtonLayout == 1) {
            fireButton.anchorMin = new Vector2(0, 0);
            fireButton.anchorMax = new Vector2(0, 0);
            fireButton.anchoredPosition = new Vector2(250, 250);

        }
        else {
            fireButton.anchorMin = new Vector2(1, 0);
            fireButton.anchorMax = new Vector2(1, 0);
            fireButton.anchoredPosition = new Vector2(-250, 250);
        }
    }

}

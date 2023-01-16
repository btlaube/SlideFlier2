using UnityEngine;
using TMPro;

public class HighscoreCanvasScript : MonoBehaviour {

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private TMP_Text playerHighscoreText;

    void Update() {
        playerHighscoreText.text = $"{playerStats.playerHighscore.value}";
    }

}

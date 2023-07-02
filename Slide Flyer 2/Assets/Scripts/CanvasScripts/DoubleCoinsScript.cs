using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoubleCoinsScript : MonoBehaviour
{
    public int coinsThisRound;
    public int initialCoins;
    public bool hasDoubled;

    public Button doubleCoinsButton;
    public TMP_Text coinsText;

    [SerializeField] private PlayerStats playerStats;

    private void Awake()
    {
        initialCoins = playerStats.playerCoins.value;
    }

    private void Start()
    {
        coinsThisRound = 0;
    }

    private void Update()
    {
        coinsText.text = "+" + coinsThisRound.ToString();
        coinsThisRound = playerStats.playerCoins.value - initialCoins;

        doubleCoinsButton.interactable = !hasDoubled;
    }

    public void DoubleCoins()
    {
        playerStats.playerCoins.value += coinsThisRound;
        hasDoubled = true;
        coinsText.text = "+" + (2 * coinsThisRound).ToString();
    }
}

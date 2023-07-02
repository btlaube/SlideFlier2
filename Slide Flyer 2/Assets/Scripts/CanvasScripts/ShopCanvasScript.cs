using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCanvasScript : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    public void WatchAd(int reward)
    {
        playerStats.playerCoins.value += reward;
    }
}

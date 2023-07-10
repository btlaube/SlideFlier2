using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonManager : MonoBehaviour {
    
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private List<GameObject> shopItems;

    [SerializeField] private GameEvent equippedPlaneChanged;
    [SerializeField] private GameEvent planePurchased;

    void Start() {
        foreach(Transform child in transform) {
            shopItems.Add(child.gameObject);
        }
        SetButtons();
    }

    private void SetButtons() {
        for (int i = 0; i < shopItems.Count; i++) {
            if (playerStats.unlockedPlanes.values[i] == 1) {
                shopItems[i].GetComponent<ShopItemScript>().SetPurchased();
            }
            if (playerStats.equippedPlaneIndex.value == i) {
                shopItems[i].GetComponent<ShopItemScript>().Equip();
            }
        }
    }

    public void AddPlane(GameObject shopItem) {
        int index = shopItems.FindIndex(a => a == shopItem);
        playerStats.unlockedPlanes.values[index] = 1;

        OnPlanePurchased();
    }

    public void EquipPlane(GameObject shopItem) {

        for (int i = 0; i < shopItems.Count; i++) {
            if (shopItems[i] == shopItem) {
                playerStats.equippedPlaneIndex.value = i;
            }
            else {
                shopItems[i].GetComponent<ShopItemScript>().Unequip();
            }
        }

        OnEquippedPlaneChanged();
    }

    public void OnEquippedPlaneChanged() {
        equippedPlaneChanged.TriggerEvent();
    }    
    
    public void OnPlanePurchased() {
        planePurchased.TriggerEvent();
    }    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonManager : MonoBehaviour {
    
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private List<GameObject> shopItems;

    [SerializeField] private GameEvent equippedPlaneChanged;

    void Start() {
        foreach(Transform child in transform) {
            shopItems.Add(child.gameObject);
        }
    }

    public void AddPlane(GameObject shopItem) {
        int index = shopItems.FindIndex(a => a == shopItem);
        playerStats.unlockedPlanes[index] = 1;
    }

    public void EquipPlane(GameObject shopItem) {

        for (int i = 0; i < shopItems.Count; i++) {
            if (shopItems[i] == shopItem) {
                playerStats.equippedPlane = i;
            }
            else {
                shopItems[i].GetComponent<ShopItemScript>().Unequip();
            }
        }

        //OnEquippedPlaneChanged();
    }

    public void OnEquippedPlaneChanged() {
        equippedPlaneChanged.TriggerEvent();
    }    

}

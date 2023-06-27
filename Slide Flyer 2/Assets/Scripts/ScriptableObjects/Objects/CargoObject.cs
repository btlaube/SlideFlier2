using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cargo Object", menuName = "ScriptableObject/Obstacle/Cargo")]
public class CargoObject : ScriptableObject {
    public SpawnableSpeed speed;
    public SpawnableDamage damage;
    public Sprite[] sprites;
    public int health;
    public PickUpObject drop;
    public GameObject breakEffect;
}

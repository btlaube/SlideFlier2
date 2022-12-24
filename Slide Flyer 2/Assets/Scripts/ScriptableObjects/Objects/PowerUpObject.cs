using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Power Up Object", menuName = "ScriptableObject/Power Up")]
public class PowerUpObject : ScriptableObject {
    public Sprite sprite;
    public SpawnableSpeed speed;
}

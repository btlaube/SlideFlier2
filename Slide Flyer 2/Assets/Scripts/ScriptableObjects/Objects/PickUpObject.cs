using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pick Up", menuName = "ScriptableObject/Pick Up")]
public class PickUpObject : SpawnableObject {
    public Sprite sprite;
    //change from string
    public string ability;
}

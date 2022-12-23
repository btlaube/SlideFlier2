using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cargo Object", menuName = "ScriptableObject/Obstacle/Cargo")]
public class CargoObject : ObstacleObject {
    public PickUpObject drop;
}

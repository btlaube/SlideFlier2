using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New IntList", menuName = "ScriptableObject/IntList")]
public class IntList : ScriptableObject {
    public int[] values;
}
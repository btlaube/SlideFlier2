using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PreferencesData", menuName = "ScriptableObject/Setting/PreferencesData")]
public class PreferencesData : ScriptableObject {
    //Volume data
    public AudioVolumeFloat soundEffectVolume;
    public AudioVolumeFloat musicVolume;

    //Controls data
    public int fireButtonLayout;
}

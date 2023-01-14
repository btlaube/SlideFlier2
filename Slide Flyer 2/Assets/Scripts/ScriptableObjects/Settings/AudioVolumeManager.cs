using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AudioVolumeManager", menuName = "ScriptableObject/Setting/AudioVolumeManager")]
public class AudioVolumeManager : ScriptableObject {
    public AudioVolumeFloat soundEffectVolume;
    public AudioVolumeFloat musicVolume;
}

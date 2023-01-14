using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsCanvasScript : MonoBehaviour {
    
    [SerializeField] private Toggle soundEffectToggle;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private AudioVolumeManager audioVolumeManager;

    void Start() {
        UpdateVolumeSettings();
    }

    public void UpdateVolumeSettings() {
        audioVolumeManager.soundEffectVolume.value = soundEffectToggle.isOn ? 1f : 0f;
        audioVolumeManager.musicVolume.value = musicToggle.isOn ? 1f : 0f;
    }

}

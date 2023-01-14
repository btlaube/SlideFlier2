using UnityEngine;
using UnityEngine.UI;

public class OptionsCanvasScript : MonoBehaviour {
    
    [SerializeField] private PreferencesData preferencesData;

    [SerializeField] private Slider soundEffectVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;

    [SerializeField] private GameEvent soundEffectVolumeChanged;
    [SerializeField] private GameEvent musicVolumeChanged;

    void Start() {
        soundEffectVolumeSlider.value = preferencesData.soundEffectVolume.value;
        musicVolumeSlider.value = preferencesData.musicVolume.value;
    }

    public void OnSoundEffectVolumeChanged() {
        preferencesData.soundEffectVolume.value = soundEffectVolumeSlider.value;
        soundEffectVolumeChanged.TriggerEvent();
    }

    public void OnMusicVolumeChanged() {
        musicVolumeChanged.TriggerEvent();
    }

}

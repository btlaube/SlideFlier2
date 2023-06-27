using UnityEngine;
using UnityEngine.UI;

public class OptionsCanvasScript : MonoBehaviour {
    
    [SerializeField] private PreferencesData preferencesData;

    [SerializeField] private Slider soundEffectVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;

    [SerializeField] private GameEvent soundEffectVolumeChanged;
    [SerializeField] private GameEvent musicVolumeChanged;

    [SerializeField] private Button fireButtonLeft;
    [SerializeField] private Button fireButtonRight;

    [SerializeField] private GameEvent fireButtonLayoutChanged;

    [SerializeField] private Slider movementSensitivitySlider;

    [SerializeField] private GameEvent movementSensitivityChanged;

    void Start() {
        soundEffectVolumeSlider.value = preferencesData.soundEffectVolume.value;
        musicVolumeSlider.value = preferencesData.musicVolume.value;

        fireButtonLeft.interactable = preferencesData.fireButtonLayout == 0;
        fireButtonRight.interactable = preferencesData.fireButtonLayout == 1;

        movementSensitivitySlider.value = preferencesData.movementSensitivity;
    }

    public void OnSoundEffectVolumeChanged() {
        preferencesData.soundEffectVolume.value = soundEffectVolumeSlider.value;
        soundEffectVolumeChanged.TriggerEvent();
    }

    public void OnMusicVolumeChanged() {
        preferencesData.musicVolume.value = musicVolumeSlider.value;
        musicVolumeChanged.TriggerEvent();
    }

    public void LeftButtonClicked() {
        preferencesData.fireButtonLayout = 1;
        fireButtonLeft.interactable = false;
        fireButtonRight.interactable = true;

        OnFireButtonLayoutChanged();
    }

    public void RightButtonClicked() {
        preferencesData.fireButtonLayout = 0;
        fireButtonLeft.interactable = true;
        fireButtonRight.interactable = false;

        OnFireButtonLayoutChanged();
    }

    public void OnFireButtonLayoutChanged() {
        fireButtonLayoutChanged.TriggerEvent();
    }

    public void OnMovementSensitivityChanged() {
        preferencesData.movementSensitivity = (int)movementSensitivitySlider.value;
        movementSensitivityChanged.TriggerEvent();
    }

}

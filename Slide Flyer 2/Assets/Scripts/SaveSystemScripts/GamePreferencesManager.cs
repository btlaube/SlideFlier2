using UnityEngine;

public class GamePreferencesManager : MonoBehaviour {

    [SerializeField] private PreferencesData preferencesData;

    const string SoundEffectVolumeKey = "SoundEffectVolume";
    const string MusicVolumeKey = "MusicVolume";
    const string FireButtonLayoutKey = "FireButtonLayout";
    const string MovementSensitivityKey = "MovementSensitivity";

    void Start() {
        LoadPrefs();
    }

    public void SavePrefs() {
        PlayerPrefs.SetFloat(SoundEffectVolumeKey, preferencesData.soundEffectVolume.value);
        PlayerPrefs.SetFloat(MusicVolumeKey, preferencesData.musicVolume.value);
        PlayerPrefs.SetInt(FireButtonLayoutKey, preferencesData.fireButtonLayout);
        PlayerPrefs.SetInt(MovementSensitivityKey, preferencesData.movementSensitivity);

        PlayerPrefs.Save();
    }

    public void LoadPrefs() {
        preferencesData.soundEffectVolume.value = PlayerPrefs.GetFloat(SoundEffectVolumeKey, 1f);
        preferencesData.musicVolume.value = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
        preferencesData.fireButtonLayout = PlayerPrefs.GetInt(FireButtonLayoutKey, 0);
        preferencesData.movementSensitivity = PlayerPrefs.GetInt(MovementSensitivityKey, 2);
    }
        
}

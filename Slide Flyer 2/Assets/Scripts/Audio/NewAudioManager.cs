using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class NewAudioManager : MonoBehaviour {

    public Sound[] sounds;
    [SerializeField] private AudioVolumeManager audioVolumeManager;

    void Awake() {
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            if (s.isSoundEffect) {
                s.source.volume = s.volume * audioVolumeManager.soundEffectVolume.value;
            }
            else if (s.isMusic) {
                s.source.volume = s.volume * audioVolumeManager.musicVolume.value;
            }
            
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            Debug.Log("No such audio clip");
        s.source.Play();        
    }
    
    public void Stop(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            Debug.Log("No such audio clip");
        s.source.Stop();        
    }

    public void RandomizePitch(string name, float low, float high) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            Debug.Log("No such audio clip");
        s.source.pitch = UnityEngine.Random.Range(low, high);        
    }

}

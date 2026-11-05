using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSystem : MonoBehaviour
{
    public GameObject backGroundSound;
    public Slider _slider;

    private AudioSource _audio;

    void Awake()
    {
        _audio = backGroundSound.GetComponent<AudioSource>();
    }

    void Start()
    {
        _slider.value = _audio.volume = AudioVolume.soundVolume;
    }

    public void ChangeSoundVolume(float value)
    {
        AudioVolume.soundVolume = _audio.volume = value;
    }
}

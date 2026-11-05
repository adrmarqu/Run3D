using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSystem : MonoBehaviour
{
    public GameObject backGroundMusic;
    public Slider _slider;

    private AudioSource _audio;

    void Awake()
    {
        _audio = backGroundMusic.GetComponent<AudioSource>();
    }

    void Start()
    {
        _slider.value = _audio.volume = AudioVolume.musicVolume;
    }

    public void ChangeMusicVolume(float value)
    {
        AudioVolume.musicVolume = _audio.volume = value;
    }
}

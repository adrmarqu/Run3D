using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundSystem : MonoBehaviour
{
    private AudioSource _audio;

    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        _audio.Play();
    }

    public void PutSound(AudioClip sound)
    {
        _audio.clip = sound;
        PlaySound();
    }
}

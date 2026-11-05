using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public AudioClip sound;

    private GameObject canvas;
    private GameObject backGroundSound;

    private CanvasCoins _coins;
    private DestroyPoolingSystem _destroy;
    private PlaySoundSystem _play;

    private void Awake()
    {
        _destroy = GetComponent<DestroyPoolingSystem>();
    }

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("CanvasInGame");
        backGroundSound = GameObject.FindGameObjectWithTag("SoundController");

        _coins = canvas.GetComponent<CanvasCoins>();
        _play = backGroundSound.GetComponent<PlaySoundSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CoinSystem.coins += 10;
        _coins.CoinCanvas();
        _play.PutSound(sound);
        _destroy.DesactiveObjects();
    }
}

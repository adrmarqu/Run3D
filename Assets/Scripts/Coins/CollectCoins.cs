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

        if (canvas != null)
        {
            _coins = canvas.GetComponent<CanvasCoins>();
        }
        if (backGroundSound != null)
        {
            _play = backGroundSound.GetComponent<PlaySoundSystem>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if (layerName.Equals("Followers") || layerName.Equals("PlayerController") || other.CompareTag("Player") || other.CompareTag("Follower"))
        {
            CoinSystem.coins += 10;
            if (_coins != null)
            {
                _coins.CoinCanvas();
            }
            if (_play != null && sound != null)
            {
                _play.PutSound(sound);
            }
            if (_destroy != null)
            {
                _destroy.DesactiveObjects();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}

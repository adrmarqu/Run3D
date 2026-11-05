using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Colision para recoger seguidores
// Este script solo lo llevan los seguidores que estan por el mapa

public class FollowerCollision : MonoBehaviour
{
    private DestroyPoolingSystem _destroy;
    private FollowersSystem follow;
    private GameObject _player;

    private void Awake()
    {
        _destroy = GetComponent<DestroyPoolingSystem>();
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        follow = _player.GetComponent<FollowersSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Followers"))
        {
            _destroy.DesactiveObjects();
            follow.AddFollower();
        }
    }
}

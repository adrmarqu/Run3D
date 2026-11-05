using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHealth : HealthSystem
{
    private DestroyPoolingSystem _ds;
    private FollowersSystem _follower;

    private GameObject player;

    private void Awake()
    {
        _ds = GetComponent<DestroyPoolingSystem>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        _follower = player.GetComponent<FollowersSystem>();
    }

    public override void Health()
    {
        if (!GodPlayerSystem.inmunity)
        {
            _follower.LostFollower();   // Canvas
            _follower.CheckFollowers(); // Comprovar que queden seguidores
            _ds.DesactiveObjects(); // Muerte
        }
    }
}

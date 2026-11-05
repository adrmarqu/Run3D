using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowersSystem : MonoBehaviour
{
    [Header("Canvas")]
    private GameObject canvasGame;  
    private GameObject canvasLevel;

    private int followers;  // Cantidad seguidores

    private LevelCompleted _levelDead;
    private CanvasFollowers _canvasFollowers;
    private FollowerFormationSystem _followerF;

    private void Awake()
    {
        _followerF = GetComponent<FollowerFormationSystem>();
    }

    private void Start()
    {
        canvasLevel = GameObject.FindGameObjectWithTag("CanvasLevel");
        _levelDead = canvasLevel.GetComponent<LevelCompleted>();

        canvasGame = GameObject.FindGameObjectWithTag("CanvasInGame");
        _canvasFollowers = canvasGame.GetComponent<CanvasFollowers>();

        followers = 1;
    }

    // Añadir seguidor

    public void AddFollower()
    {
        followers++;
        _canvasFollowers.FollowerCanvas(followers);
        _followerF.AddFollower();
    }

    // Quitar seguidor desde los trucos

    public void RemoveFollower()
    {
        LostFollower();
        _followerF.RemoveFollower();

        CheckFollowers();
    }

    // Mirar si aun quedan seguidores

    public void CheckFollowers()
    {
        if (followers <= 0)
        {
            followers = 0;
            _levelDead.deathPanel();
            _canvasFollowers.FollowerCanvas(followers);
        }
    }

    // Quitar seguidor cuando muere

    public void LostFollower()
    {
        followers--;
        _canvasFollowers.FollowerCanvas(followers);
    }
}

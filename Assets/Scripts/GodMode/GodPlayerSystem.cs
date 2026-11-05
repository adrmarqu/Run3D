using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodPlayerSystem : MonoBehaviour
{
    public static bool inmunity;

    [Header("Activar inmunidad")]
    public bool activeInmunity;

    [Header("Activar añadir y quitar seguidores")]
    public bool activeFollowers;

    [Header("Añadir seguidor o con la tecla E")]
    public bool addFollow;

    [Header("Quitar seguidor o con la tecla R")]
    public bool removeFollow;

    private FollowersSystem _follow;

    private void Awake()
    {
        _follow = GetComponent<FollowersSystem>();
    }

    void Update()
    {
        inmunity = activeInmunity;

        if (activeFollowers)
        {
            if (Input.GetKeyDown(KeyCode.E) || addFollow)
            {
                _follow.AddFollower();
                addFollow = false;
            }
            if (Input.GetKeyDown(KeyCode.R) || removeFollow)
            {
                _follow.RemoveFollower();
                removeFollow = false;
            }
        }
    }
}

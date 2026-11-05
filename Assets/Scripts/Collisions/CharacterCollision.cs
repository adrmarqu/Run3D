using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Colision entre seguidores y enemigos
// Solo lo llevan los enemigos

public class CharacterCollision : MonoBehaviour
{

    private EnemyHealth _health;

    private void Awake()
    {
        _health = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Followers"))
        {
            other.GetComponent<AllyHealth>().Health();
            _health.Health();
        }
    }
}

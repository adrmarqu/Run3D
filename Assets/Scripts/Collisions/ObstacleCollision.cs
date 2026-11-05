using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Colision entre obstaculos y seguidores
// Solo lo llevan los objetos que no tienen vida

public class ObstacleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Followers"))
        {
            other.GetComponent<AllyHealth>().Health();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovilObstacleCollision : MonoBehaviour
{
    private Animation _anim;
    private MovilObstacleCollision _obj;

    private void Awake()
    {
        _anim = GetComponent<Animation>();
        _obj = GetComponent<MovilObstacleCollision>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Followers"))
        {
            other.GetComponent<AllyHealth>().Health();
            _anim.Play();
            Destroy(_obj);
        }
    }
}

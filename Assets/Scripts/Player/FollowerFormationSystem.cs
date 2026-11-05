using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerFormationSystem : MonoBehaviour
{
    private GameObject follower;
    private GameObject player;
    private GameObject objPool;

    private Vector3 pos;
    private int followerNum;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            player = gameObject;
        }
        followerNum = 1;
    }

    public void AddFollower()
    {
        objPool = PoolingManager.Instance.GetPooledObject("Follower");
        if (objPool != null)
        {
            objPool.transform.position = GetPosition();
            if (player != null)
            {
                objPool.transform.rotation = player.transform.rotation;
            }

            objPool.name = "follower" + followerNum;
            followerNum++;

            objPool.SetActive(true);

            if (player != null)
            {
                objPool.transform.SetParent(player.transform);
            }

            SetCharacterColor colorComp = objPool.GetComponent<SetCharacterColor>();
            if (colorComp != null)
            {
                colorComp.PaintCharacters();
            }
        }
    }

    public void RemoveFollower()
    {
        follower = GameObject.FindGameObjectWithTag("Follower");
        if (follower != null)
        {
            DestroyPoolingSystem poolDest = follower.GetComponent<DestroyPoolingSystem>();
            if (poolDest != null)
            {
                poolDest.DesactiveObjects();
            }
            else
            {
                follower.SetActive(false);
            }
        }
    }

    Vector3 GetPosition()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        follower = GameObject.FindGameObjectWithTag("Follower");

        Vector3 basePos = (follower != null) ? follower.transform.position : (player != null ? player.transform.position : transform.position);

        pos.x = Random.Range(-10, 10) + (player != null ? player.transform.position.x : transform.position.x);
        pos.y = basePos.y;
        pos.z = Random.Range(-10, 10) + basePos.z;

        return pos;
    }
}

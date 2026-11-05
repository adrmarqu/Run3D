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
        followerNum = 1;
    }

    public void AddFollower()
    {
        objPool = PoolingManager.Instance.GetPooledObject("Follower");
        if (objPool != null)
        {
            objPool.transform.position = GetPosition();
            objPool.transform.rotation = player.transform.rotation;

            objPool.name = "follower" + followerNum;
            followerNum++;

            objPool.SetActive(true);

            objPool.transform.SetParent(player.transform);
            objPool.GetComponent<SetCharacterColor>().PaintCharacters();
        }
    }

    public void RemoveFollower()
    {
        follower = GameObject.FindGameObjectWithTag("Follower");
        if (follower != null)
        {
            follower.GetComponent<DestroyPoolingSystem>().DesactiveObjects();
        }
    }

    Vector3 GetPosition()
    {
        follower = GameObject.FindGameObjectWithTag("Follower");

        pos.x = Random.Range(-10,10);
        pos.x = pos.x + player.transform.position.x;

        pos.y = follower.transform.position.y;
        
        pos.z = Random.Range(-10, 10);
        pos.z = pos.z + follower.transform.position.z;

        return pos;
    }
}

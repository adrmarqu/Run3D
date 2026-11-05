using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public GameObject[] spawn;

    private void Start()
    {
        resetPlayer();
    }

    public void resetPlayer()
    {
        transform.position = new Vector3(spawn[LevelSystem.level].transform.position.x, transform.position.y, 0);
    }
}

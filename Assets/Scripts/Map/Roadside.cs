using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roadside : MonoBehaviour
{
    public float speed = 100.0f;
    public float segmentLength = 1000.0f;

    Vector3 basePosition;

    float offset;

    // Start is called before the first frame update
    void Start()
    {
        basePosition = transform.position;
        offset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused && InputSystemKeyBoard.moveMap) 
        {
            offset -= speed * Time.deltaTime;

            if (offset < -segmentLength) 
            { 
                offset += segmentLength;
            }

            transform.position = basePosition - offset * Vector3.right;
        }
    }
}

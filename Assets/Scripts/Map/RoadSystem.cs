using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSystem : MonoBehaviour
{
    public float speed = 100.0f;
    public float segmentLength = 1000.0f;

    public GameObject[] maps;

    private Vector3 basePosition;

    private float offset;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        basePosition = transform.position;
        offset = 0;
        index = 3;

        for (int i = 3; i < maps.Length; i++)   // Se activan las primeras tres partes del mapa
        {
            if (maps[i] != null)
            {
                maps[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused && InputSystemKeyBoard.moveMap)
        {
            offset -= speed * Time.deltaTime;

            if (offset < -segmentLength)
            {
                if (index - 3 >= 0 && index - 3 < maps.Length && maps[index - 3] != null)
                {
                    maps[index - 3].SetActive(false);
                }

                if (index < maps.Length && maps[index] != null)
                {
                    maps[index].SetActive(true);
                }

                if (index < maps.Length)
                {
                    index++;
                }

                offset += segmentLength;
            }
        }
    }
}

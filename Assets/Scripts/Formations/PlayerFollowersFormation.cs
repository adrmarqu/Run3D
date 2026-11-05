using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowersFormation : MonoBehaviour
{
    public GameObject parent;

    public int max_filas;

    private int[] limit = new int[20];  // Cantidad de seguidores por fila 
    private Vector3 posInitial;

    private Vector3 pos = new Vector3();
    private GameObject follower;

    //GameObject shot = PoolingManager.Instance.GetPooledObject("FireBall");

    void Start()
    {
        pos.y = 6;
        posInitial.z = 0;

        for (int i = 0; i < max_filas; i++)
        {
            limit[i] = i + 2;
        }

        Formation();
    }

    void Formation()
    {
        int num_followers = 0;

        for (int i = 0; i < max_filas; i++) // i = filas
        {
            posInitial.z = posInitial.z - 2.5f;   // Por cada fila la primera z estara 0.5 mas a la izquierda

            for (int j = 0; j < limit[i]; j++) // j = seguidores
            {
                pos.x = i * 5 + 5;      // +5 para no estar en la posicion del player
                pos.z = posInitial.z + (5 * j);

                follower = PoolingManager.Instance.GetPooledObject("Follower");
                if (follower != null)
                {
                    follower.transform.position = new Vector3(pos.x, pos.y, pos.z);

                    if (parent != null)
                    {
                        follower.transform.SetParent(parent.transform);
                    }

                    num_followers++;
                }
            }
        }
    }
}

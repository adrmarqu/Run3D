using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateCoins : MonoBehaviour
{
    [Serializable]
    public struct massCoinsLevel
    {
        public GameObject parent;
        public Vector3 initialPosition;
        public int numRows;
        public int numColumns;
    };

    [Serializable]
    public struct lineCoinsLevel
    {
        public GameObject parent;
        public Vector3 initialPosition;
        public int numCoins;
    };

    public lineCoinsLevel[] lineCoins;
    public massCoinsLevel[] massCoins;


    private GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < lineCoins.Length; i++)
        {
            LineGold(i);
        }
        for (int i = 0; i < massCoins.Length; i++)
        {
            if (massCoins[i].numColumns > 7)    // Solo puede haber un maximo de 7 columnas
            {
                massCoins[i].numColumns = 7;
            }
            MassGold(i);
        }
    }

    private void LineGold(int index)
    {
        Vector3 pos = lineCoins[index].initialPosition;

        for (int i = 0; i < lineCoins[index].numCoins; i++)
        {
            coin = PoolingManager.Instance.GetPooledObject("Coins");

            if (coin != null)
            {
                coin.transform.position = pos;
                coin.transform.rotation = transform.rotation;   // Angulo 0

                coin.SetActive(true);

                coin.transform.SetParent(lineCoins[index].parent.transform);
                coin.name = "Coin" + i;

                pos.x = pos.x - 10;
            }
        }
    }

    private void MassGold(int index)
    {
        Vector3 pos = massCoins[index].initialPosition;

        for (int i = 0; i < massCoins[index].numRows; i++)
        {
            pos.z = massCoins[index].initialPosition.z;

            pos.x = massCoins[index].initialPosition.x - 10 * i;

            for (int j = 0; j < massCoins[index].numColumns; j++)
            {
                coin = PoolingManager.Instance.GetPooledObject("Coins");

                if (coin != null)
                {
                    pos.z = massCoins[index].initialPosition.z + (10 * j);

                    coin.transform.position = pos;
                    coin.transform.rotation = transform.rotation;   // Angulo 0

                    coin.SetActive(true);

                    coin.transform.SetParent(massCoins[index].parent.transform);
                    coin.name = "Coin" + i + j;
                }
            }
        }
    }
}

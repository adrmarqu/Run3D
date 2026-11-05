using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFollowerSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject follower;

    public int numRows;

    [Header("Posicion del primer follower")]
    public Vector3 initialPosition;

    [Header("Rotacion de los followers")]
    public Vector3 followerRotation;

    private int indexPos;
    private Vector3 spawnPosition = new Vector3();
    private float posZ;
    private int row;            // Fila
    private int positionRow;    // Posicion de la fila

    private GameObject[] followerObject = new GameObject[100];

    private void Start()
    {
        indexPos = 0;
        spawnPosition = initialPosition;
        row = 1;
        positionRow = 0;

        InitializeFormation();
    }


    // X son las filas y Z las posiciones de las filas

    private void InitializeFormation()
    {
        followerObject[indexPos] = Instantiate(follower, spawnPosition, transform.rotation);
        followerObject[indexPos].transform.SetParent(player.transform);
        followerObject[indexPos].SetActive(true);
        followerObject[indexPos].transform.Rotate(followerRotation);
        followerObject[indexPos].name = "Follower00";

        indexPos++;

        initialPosition.x = initialPosition.x + 6;
        initialPosition.z = initialPosition.z - 3;

        for (int i = 1; i <= numRows; i++)
        {
            posZ = initialPosition.z * i;
            spawnPosition.x = initialPosition.x * i;

            for (int j = 0; j <= i; j++)
            {
                spawnPosition.z = posZ + 6 * j;

                followerObject[indexPos] = Instantiate(follower, spawnPosition, transform.rotation);
                followerObject[indexPos].transform.SetParent(player.transform);
                followerObject[indexPos].SetActive(false);
                followerObject[indexPos].transform.Rotate(followerRotation);
                followerObject[indexPos].name = "Follower" + i + j;

                indexPos++;
            }
        }
        indexPos = 1;
    }

    public void AddFollowerFormation()
    {
        followerObject[indexPos].SetActive(true);

        if (positionRow >= row)     // Pasar de fila
        {
            positionRow = 0;
            row++;
        }
        else    // Siguiente posicion
        {
            positionRow++;
        }
        indexPos++;   
    }

    public void RemoveFollowerFormation()
    {
        followerObject[indexPos - 1].SetActive(false);

        if (positionRow <= 0)     // Pasar de fila
        {
            row--;
            positionRow = row;
        }
        else    // Siguiente posicion
        {
            positionRow--;
        }
        indexPos--;
    }
}
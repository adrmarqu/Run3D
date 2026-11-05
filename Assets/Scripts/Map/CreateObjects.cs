using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Para spawnear cualquier objeto que no use formaciones

public class CreateObjects : MonoBehaviour
{
    [Serializable]
    public struct mapObjects
    {
        public string objectName;
        public GameObject parent;
        public Vector3[] obstaclePosition;
        public Vector3 obstacleRotation;
    };

    public mapObjects[] levelObjects;

    private GameObject objPooled;

    private void Start()
    {
        for (int j = 0; j < levelObjects.Length; j++)
        {
            for (int i = 0; i < levelObjects[j].obstaclePosition.Length; i++)
            {
                objPooled = PoolingManager.Instance.GetPooledObject(levelObjects[j].objectName);

                if (objPooled != null)
                {
                    objPooled.transform.position = levelObjects[j].obstaclePosition[i];
                    objPooled.transform.rotation = Quaternion.Euler(levelObjects[j].obstacleRotation);

                    objPooled.SetActive(true);

                    objPooled.transform.SetParent(levelObjects[j].parent.transform);
                    objPooled.name = "Coin" + i;
                }
            }
        }
    }
}

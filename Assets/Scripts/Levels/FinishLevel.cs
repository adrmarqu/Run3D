using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private GameObject canvasLevel;

    private LevelCompleted _lvl;

    private void Start()
    {
        canvasLevel = GameObject.FindGameObjectWithTag("CanvasLevel");

        if (canvasLevel != null)
        {
            _lvl = canvasLevel.GetComponent<LevelCompleted>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if (layerName.Equals("Followers") || layerName.Equals("PlayerController") || other.CompareTag("Player") || other.CompareTag("Follower"))
        {
            if (_lvl != null)
            {
                _lvl.activePanel();
            }
        }
    }
}

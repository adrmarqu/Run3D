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

        _lvl = canvasLevel.GetComponent<LevelCompleted>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Followers"))
        {
            _lvl.activePanel();
        }
    }
}

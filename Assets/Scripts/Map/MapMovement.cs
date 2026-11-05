using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    public float VerticalSpeed;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!PauseMenu.GameIsPaused && InputSystemKeyBoard.moveMap)
        {
            _rb.velocity = new Vector3(VerticalSpeed, 0, 0);
        }
        else if (!InputSystemKeyBoard.moveMap || PauseMenu.GameIsPaused)
        {
            _rb.velocity = Vector3.zero;
        }
    }
}

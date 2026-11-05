using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float cameraVelocity;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            _rb.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            _rb.velocity = new Vector3(-cameraVelocity * Time.timeScale, 0, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public float HorizontalSpeed;

    private InputSystemKeyBoard _input;
    private CharacterController _controller;
    private Animator _anim;

    private GameObject playerC;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        playerC = GameObject.FindGameObjectWithTag("Player");

        _input = playerC.GetComponent<InputSystemKeyBoard>();

        _anim.SetBool("run", false);
    }

    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            if (InputSystemKeyBoard.moveMap)
            {
                _controller.Move(transform.right * HorizontalSpeed * Time.deltaTime * _input.hor);
                transform.rotation = Quaternion.Euler(0, -90, 0);   // Para que mire hacia delante
                _anim.SetBool("run", true);
            }
            else
            {
                _anim.SetBool("run", false);
            }
        }
    }
}

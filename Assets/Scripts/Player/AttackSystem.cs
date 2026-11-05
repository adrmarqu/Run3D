using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public float persueSpeed;

    private GameObject target;

    private CharacterController _controller;
    private Engine _engine;

    private bool persue;

    private Vector3 targetOffset;
    private Vector3 targetOffsetProjected;
    private Vector3 targetOffsetNormalized;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _engine = GetComponent<Engine>();
    }

    private void Start()
    {
        persue = false;
    }

    public void Attack(GameObject enemy)
    {
        target = enemy;
        if (!GodPlayerSystem.inmunity) // Que no persiga si es inmune
        {
            persue = true;

            if (_engine != null)
            {
                _engine.enabled = false; // Desactivar engine temporalmente para que persiga al enemigo
            }
        }
    }

    public void StopAttack()
    {
        persue = false;
        target = null;
        if (_engine != null)
        {
            _engine.enabled = true; // Restaurar engine cuando termina el ataque
        }
    }

    private void Update()
    {
        if (persue && !PauseMenu.GameIsPaused)
        {
            if (target == null || !target.activeInHierarchy)
            {
                StopAttack();
                return;
            }

            targetOffset = target.transform.position - transform.position;
            targetOffset = new Vector3(targetOffset.x, 0, targetOffset.z);

            targetOffsetProjected = new Vector3(targetOffset.x, 0, targetOffset.z);
            targetOffsetNormalized = targetOffsetProjected.normalized;

            if (_controller != null)
            {
                _controller.Move(targetOffsetNormalized * persueSpeed * Time.deltaTime);
            }
        }
    }

    public bool GetState()
    {
        return persue;
    }
}

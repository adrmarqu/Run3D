using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : DetectionSystem
{
    private Animator _anim;

    private void Start()
    {
        _anim = main.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Followers") && !objectFinded)
        {
            // Comprovar si ya esta atacando a otro

            if (!other.GetComponent<AttackSystem>().GetState())
            {
                objectFinded = true;        // Objetivo encontrado
                _anim.SetBool("run", true); // Empieza a correr

                other.GetComponent<AttackSystem>().Attack(main);   // Que el seguidor ataque al objetivo
            } 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Si encunetra un objeto movible, el player envia a sus seguidores, si no tiene seguidores no hace nada y el objeto no se mueve

public class ObjectDetection : DetectionSystem
{
    private void Start()
    {
        objectFinded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Followers") && !objectFinded)
        {
            // Comprovar si ya esta atacando a otro

            if (!other.GetComponent<AttackSystem>().GetState())
            {
                objectFinded = true;        // Objetivo encontrado

                other.GetComponent<AttackSystem>().Attack(main);   // Que el seguidor ataque al objetivo
            }
        }
    }
}

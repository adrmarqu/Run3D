using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHammer : EffectParticleSystem
{

    private void Start()
    {
        particle.SetActive(false);
    }

    public override void ActiveParticle()
    {
        particle.SetActive(true);
    }

    public override void DesactiveParticle()
    {
        particle.SetActive(false);
    }
}

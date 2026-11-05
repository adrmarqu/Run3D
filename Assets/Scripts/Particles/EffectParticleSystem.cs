using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectParticleSystem : MonoBehaviour
{
    public GameObject particle;
    public abstract void ActiveParticle();
    public abstract void DesactiveParticle();
}

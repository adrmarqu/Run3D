using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    private DestroyPoolingSystem _ds;

    private void Awake()
    {
        _ds = GetComponent<DestroyPoolingSystem>();
    }

    public override void Health()
    {
        _ds.DesactiveObjects();
    }
}

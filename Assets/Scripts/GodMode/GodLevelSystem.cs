using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodLevelSystem : MonoBehaviour
{

    [Header("Cambiar de nivel(1-3)")]
    public bool activeLevelMode;

    private int lvl;

    private LevelController _level;

    private void Awake()
    {
        _level = GetComponent<LevelController>();
    }

    void Update()
    {
        if (activeLevelMode)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                lvl = 0;
                _level.changeLevel(lvl);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                lvl = 1;
                _level.changeLevel(lvl);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                lvl = 2;
                _level.changeLevel(lvl);
            }
        }
    }
}

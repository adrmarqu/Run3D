using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacterColor : MonoBehaviour
{
    public GameObject _mesh;

    [Header("Tipo de personaje")]
    public bool follower;
    public bool enemy;

    private Renderer render;
    private ColorMaterialSystem _material;

    private GameObject player;

    private void Awake()
    {
        render = _mesh.GetComponent<Renderer>();
    }

    private void Start()
    {
        PaintCharacters();
    }
    public void PaintCharacters()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        _material = player.GetComponent<ColorMaterialSystem>();

        if (follower)
        {
            render.material = _material.materialColor[ColorSystem.indexPlayerColor];
        }
        else if (enemy)
        {
            render.material = _material.materialColor[ColorSystem.indexEnemyColor];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject panelColor;
    public GameObject mesh;

    private ColorMaterialSystem _material;
    private Renderer render;

    void Start()
    {
        _material = panelColor.GetComponent<ColorMaterialSystem>();
        render = mesh.GetComponent<Renderer>();
    }

    public void ChangeColorCharacter(int index)
    {
        render.material = _material.materialColor[index];
    }
}

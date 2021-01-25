using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    private Renderer _colorRenderer;

    private void Start()
    {
        _colorRenderer = GetComponent<Renderer>();
        _colorRenderer.material.color = Color.red;
    }
}

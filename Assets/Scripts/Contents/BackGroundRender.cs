using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRender : MonoBehaviour
{
    private MeshRenderer    _render;
    private float           _offset;
    private float           _speed;

    private void Start()
    {
        _speed = 10.0f;
        _render = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        _offset += Time.deltaTime * _speed;
        _render.material.mainTextureOffset = new Vector2(_offset, 0);
    }
}

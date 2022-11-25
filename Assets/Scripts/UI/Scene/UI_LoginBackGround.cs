using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class UI_LoginBackGround : UI_Scene
{
    private Renderer _renderer;

    private float _speed = 0.5f;
    private float _offset = 0.1f;

    private Vector2 _offVec = Vector2.zero;

    public override void Init()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        _offVec += new Vector2(_offset * _speed * Time.deltaTime, 0);
        _renderer.material.SetTextureOffset("_MainTex", _offVec);
    }
}

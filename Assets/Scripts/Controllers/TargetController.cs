using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : CreatureController
{
    public Action<int> OnEnterEvent;

    private float       _rotateSpeed = 50.0f; // 회전속도
    private Vector3     _rotateAngle = Vector3.forward; // 회전 방향

    // GearMenu Click
    private bool        _clickedGearMenu = false;

    private void Awake()
    {
        Managers.UI.OnClickedGearMenuButton -= OnClickedGearMenuButton;
        Managers.UI.OnClickedGearMenuButton += OnClickedGearMenuButton;
    }

    protected override void Init()
    {
        base.Init();

        Debug.Log("Target Start");

        _objectType = Define.WorldObject.Target;
        State = Define.CreatureState.Rotate;
    }

    protected override void UpdateRotate()
    {
        if (!_clickedGearMenu)
        {
            // 방향 * 속도 * Time.deltaTime으로 오브젝트 회전
            if (_rotateSpeed > 0)
                transform.Rotate(_rotateSpeed * _rotateAngle * Time.deltaTime);
        }   
    }

    // Game Over 일 경우
    protected override void UpdateDead()
    {

    }

    public void Stop()
    {
        _rotateSpeed = 0;
    }
    public void RotateFast()
    {
        _rotateSpeed = 500;
    }

    private void OnClickedGearMenuButton(bool clicked)
    {
        if (clicked == true)
        {
            _clickedGearMenu = clicked;
        }
        else
        {
            _clickedGearMenu = false;
        }

    }
}

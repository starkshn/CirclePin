using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : CreatureController
{
    private float   _rotateSpeed = 50.0f; // 회전속도
    private Vector3 _rotateAngle = Vector3.forward; // 회전 방향

    public Action<int> OnEnterEvent;

    protected override void Init()
    {
        base.Init();

        Debug.Log("Target Start");

        _objectType = Define.WorldObject.Target;
        State = Define.CreatureState.Rotate;

        OnEnterEvent -= CollisionEnterEvent;
        OnEnterEvent += CollisionEnterEvent;
    }

    protected override void UpdateRotate()
    {
        // 방향 * 속도 * Time.deltaTime으로 오브젝트 회전
        transform.Rotate(_rotateSpeed * _rotateAngle * Time.deltaTime);

    }


    protected override void UpdateDead()
    {

    }

    public void CollisionEnterEvent(int value)
    {

    }

    public void Stop()
    {
        _rotateSpeed = 0;
    }


}

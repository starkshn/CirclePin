using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : CreatureController
{
    private float   _rotateSpeed = 50.0f; // ȸ���ӵ�
    private Vector3 _rotateAngle = Vector3.forward; // ȸ�� ����

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
        // ���� * �ӵ� * Time.deltaTime���� ������Ʈ ȸ��
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

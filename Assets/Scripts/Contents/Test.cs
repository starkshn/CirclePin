using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private float _rotateSpeed = 150.0f; // ȸ���ӵ�
    private Vector3 _rotateAngle = Vector3.up; // ȸ�� ����
    void Start()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(_rotateSpeed * _rotateAngle * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float   _rotateSpeed = 50;
    private float   _maxRotateSpeed = 500;
    private Vector3 _rotateAngle = Vector3.forward;

    public void Stop()
    {

    }
    
    public void RotateFast()
    {
        _rotateSpeed = _maxRotateSpeed;
    }

    private void Update()
    {
        transform.Rotate(_rotateSpeed * _rotateAngle * Time.deltaTime);
    }
}

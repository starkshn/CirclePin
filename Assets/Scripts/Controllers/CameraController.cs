using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;

    [SerializeField]
    Vector3 _cameraPosition = new Vector3(-10f, 10f, -10f);
    [SerializeField]
    Vector3 _cameraRotation = new Vector3(25f, 45f, 0f);

    private float _distance;

    [SerializeField]
    GameObject _player = null;

    private void Awake()
    {
        transform.position = _cameraPosition;
        transform.rotation = Quaternion.Euler(_cameraRotation);
    }
    void Start()
    {
        _distance = Vector3.Distance(transform.position, _player.transform.position);
    }

    void LateUpdate()
    {
        if (_player == null) 
            return;

        transform.position = _player.transform.position + transform.rotation * new Vector3(0, 0, -_distance);
    }

    public void SetPlayer(GameObject player)
    {
        _player = player;
    }

}

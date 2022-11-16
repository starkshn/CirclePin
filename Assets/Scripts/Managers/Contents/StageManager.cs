using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class StageManager : MonoBehaviour
{
    private GameObject          p_pinSpawner;   // pinSpawner
    private GameObject          _target;        // target Object
    private GameObject          _targetTextUI;  // targetTextUI Object

    private PinSpawner          _pinSpawner;    // pinSpawner
    private TargetController    _targetController;
    private Camera              _camera;        // MainCamera

    private Rotator             _targetRotator; // target Object Rotator
    private Rotator             _panelRotator;  // panel Object Rotator
    
    private int                 _stuckPinCount = 5;         // 과녁의 pin count
    private int                 _throwablePinCount = 10;    // 현재 스테이지를 클리어하기 위해 던져야 하는 pin count

    private Vector3     _firstPinPosition = Vector3.down * 2;       // 게임화면 하단에 배치되는 던져야 하는 핀들의 첫번째 핀 위치
    public float        _pinDistance { private set; get; } = 1;

    private Coru _coru;

    // Game Over/Clear관련
    private Color _failBackGroundColor = new Color(0.4f, 0.1f, 0.1f);
    private Color _clearBackGroundColor = new Color(0.0f, 0.5f, 0.25f);


    public bool IsGameOver { set; get; } = false;

    public void SetUp(GameObject target, GameObject pinSpawner, GameObject targetTextUI)
    {
        _target = target;
        p_pinSpawner = pinSpawner;
        _targetTextUI = targetTextUI;

        _pinSpawner = p_pinSpawner.GetComponent<PinSpawner>();
        _targetController = _target.GetComponent<TargetController>();

        //if (_coco == null)
        //    Debug.Log(123);
        //else
        //    Debug.Log(456);

        if (p_pinSpawner != null)
        {
            _pinSpawner = p_pinSpawner.GetComponent<PinSpawner>();

            // 게임 하단에 배치되는 던져야 하는 핀 오브젝트 생성
            for (int i = 0; i < _throwablePinCount; ++i)
            {
                _pinSpawner.SpawnThrowAlbePin(_firstPinPosition + Vector3.down * _pinDistance * i, _throwablePinCount - i);
            }

            // 게임 시작할 때 과녁에 배치되어 있는 핀 오브젝트 생성
            for (int i = 0; i < _stuckPinCount; ++i)
            {
                // 과녁에 배치되는 핀의 개수에 따라 일정한 간격으로 배치될 때 배치 각도
                float angle = (360 / _stuckPinCount) * i;

                _pinSpawner.SpawnStuckPin(angle, _throwablePinCount + 1 + i);
            }
        }
    }

    public void Init()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }

    public void SetSpawnThrowAblePin(int pinCount)
    {
        _throwablePinCount = pinCount;
    }

    public void SetSpawnStuckPin(int pinCount)
    {
        _throwablePinCount = pinCount;
    }

    public void GameOver()
    {
        IsGameOver = true;

        _camera.backgroundColor = _failBackGroundColor;

        _targetController.Stop();
    }

    public void GameClear()
    {
        _coru.StartCo(_targetTextUI, _target);
    }
    
    public void Clear()
    {

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private GameObject  p_pinSpawner;   // pinSpawner
    private PinSpawner  _pinSpawner;    // pinSpawner
    private Camera      _camera;        // MainCamera
    private GameObject  _target;        // target Object
    private Rotator     _targetRotator; // target Object Rotator
    private Rotator     _panelRotator;  // panel Object Rotator
    
    private int         _stuckPinCount = 5;         // 과녁의 pin count
    private int         _throwablePinCount = 10;    // 현재 스테이지를 클리어하기 위해 던져야 하는 pin count

    private Vector3     _firstPinPosition = Vector3.down * 2;       // 게임화면 하단에 배치되는 던져야 하는 핀들의 첫번째 핀 위치
    public float        _pinDistance { private set; get; } = 1;

    // Game Over/Clear관련
    private Color       _failBackGroundColor = new Color(0.4f, 0.1f, 0.1f);
    private Color       _clearBackGroundColor = new Color(0.0f, 0.5f, 0.25f);

    public bool IsGameOver { set; get; } = false;
    public Action<bool> OnClearEvent;


    public void Init()
    {
        OnClearEvent -= ClearGame;
        OnClearEvent += ClearGame;

        // Get MainCamera
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        // Get TargetObject
        _target = GameObject.FindGameObjectWithTag("Target");
        _targetRotator = _target.GetComponent<Rotator>();

        // Get Pinspawner
        p_pinSpawner = GameObject.FindGameObjectWithTag("PinSpawner");

        if (p_pinSpawner != null)
        {
            _pinSpawner = p_pinSpawner.GetComponent<PinSpawner>();

            _pinSpawner.SetUp();

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
        IsGameOver= true;

        _camera.backgroundColor = _failBackGroundColor;

        _target.GetComponent<TargetController>().Stop();
    }

    public void ClearGame(bool clear)
    {
        if (clear)
        {
            StartCoroutine("GameClear");
        }

        OnClearEvent = null;
    }

    private IEnumerator GameClear()
    {
        yield return new WaitForSeconds(0.1f);

        if (IsGameOver == true)
        {
            yield break;
        }

        // Get Panel Object
        _panelRotator = GameObject.FindGameObjectWithTag("TargetTextUI").GetComponent<Rotator>();

        _camera.backgroundColor = _clearBackGroundColor;

        _targetRotator.RotateFast();

        _panelRotator.RotateFast();
    }

    public void Clear()
    {
        
    }
}

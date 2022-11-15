using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StageManager : MonoBehaviour
{
    private GameObject  p_pinSpawner;   // pinSpawner
    private PinSpawner  _pinSpawner;    // pinSpawner
    private Camera      _camera;        // MainCamera
    private GameObject  _target;        // target Object
    private GameObject  _targetTextUI;  // targetTextUI Object
    private Rotator     _targetRotator; // target Object Rotator
    private Rotator     _panelRotator;  // panel Object Rotator
    
    private int         _stuckPinCount = 5;         // ������ pin count
    private int         _throwablePinCount = 10;    // ���� ���������� Ŭ�����ϱ� ���� ������ �ϴ� pin count

    private Vector3     _firstPinPosition = Vector3.down * 2;       // ����ȭ�� �ϴܿ� ��ġ�Ǵ� ������ �ϴ� �ɵ��� ù��° �� ��ġ
    public float        _pinDistance { private set; get; } = 1;

    // Game Over/Clear����
    private Color       _failBackGroundColor = new Color(0.4f, 0.1f, 0.1f);
    private Color       _clearBackGroundColor = new Color(0.0f, 0.5f, 0.25f);

    public bool IsGameOver { set; get; } = false;
    public Action<bool> OnClearEvent;


    public void SetUp(GameObject target, GameObject pinSpawner, GameObject targetTextUI)
    {
        _target = target;
        p_pinSpawner = pinSpawner;
        _targetTextUI = targetTextUI;

        _pinSpawner = p_pinSpawner.GetComponent<PinSpawner>();

        if (p_pinSpawner != null)
        {
            _pinSpawner = p_pinSpawner.GetComponent<PinSpawner>();

            // ���� �ϴܿ� ��ġ�Ǵ� ������ �ϴ� �� ������Ʈ ����
            for (int i = 0; i < _throwablePinCount; ++i)
            {
                _pinSpawner.SpawnThrowAlbePin(_firstPinPosition + Vector3.down * _pinDistance * i, _throwablePinCount - i);
            }

            // ���� ������ �� ���ῡ ��ġ�Ǿ� �ִ� �� ������Ʈ ����
            for (int i = 0; i < _stuckPinCount; ++i)
            {
                // ���ῡ ��ġ�Ǵ� ���� ������ ���� ������ �������� ��ġ�� �� ��ġ ����
                float angle = (360 / _stuckPinCount) * i;

                _pinSpawner.SpawnStuckPin(angle, _throwablePinCount + 1 + i);
            }
        }
    }

    public void Init()
    {
        OnClearEvent -= ClearGame;
        OnClearEvent += ClearGame;

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

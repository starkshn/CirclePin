using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class StageController : MonoBehaviour
{
    private GameObject          p_pinSpawner;       // pinSpawner
    private GameObject          _target;            // target Object
    private GameObject          _targetTextUI;      // targetTextUI Object

    private PinSpawner          _pinSpawner;        // pinSpawner
    private TargetController    _targetController;
    private CameraController    _camera;            // MainCamera

    private Rotator             _targetRotator;     // target Object Rotator
    private Rotator             _panelRotator;      // panel Object Rotator
    
    private int                 _stuckPinCount = 5;         // ������ pin count
    private int                 _throwablePinCount = 10;    // ���� ���������� Ŭ�����ϱ� ���� ������ �ϴ� pin count

    private Vector3             _firstPinPosition = Vector3.down * 2;       // ����ȭ�� �ϴܿ� ��ġ�Ǵ� ������ �ϴ� �ɵ��� ù��° �� ��ġ
    public float                _pinDistance { private set; get; } = 1;

    // Game Over/Clear����
    private Color               _failBackGroundColor = new Color(0.4f, 0.1f, 0.1f);
    private Color               _clearBackGroundColor = new Color(0.0f, 0.5f, 0.25f);

    public bool IsGameOver { set; get; } = false;

    public void SetUp(GameObject target, GameObject pinSpawner, GameObject targetTextUI)
    {
        _target = target;
        p_pinSpawner = pinSpawner;
        _targetTextUI = targetTextUI;

        _targetRotator = _targetTextUI.GetComponent<Rotator>();

        _pinSpawner = p_pinSpawner.GetComponent<PinSpawner>();
        _targetController = _target.GetComponent<TargetController>();

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

    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
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

        _camera.GameOver();

        _targetController.Stop();
    }

    public void GameClear()
    {
        Managers.UI.ShowPopupUI<UI_Popup>("UI_ClearPopup");

        StartCoroutine("GameClearCo");

    }

    public IEnumerator GameClearCo()
    {
        Debug.Log("�ڷ�ƾ �ȿ� ����");
        yield return new WaitForSeconds(0.1f);

        if (IsGameOver == true)
        {
            yield break;
        }

        // Get Component
        _targetRotator.RotateFast();
        _targetController.RotateFast();
        
        _camera.GameClear();
    }

    public void Clear()
    {

    }
}

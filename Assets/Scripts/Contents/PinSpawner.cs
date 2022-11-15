using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    private GameObject  _pin;                               // pin Object
    private GameObject  _targetObject;                      // target Object
                                                            
    private Transform   _targetTransfrom;                   // ���� ������Ʈ�� Transform
    private Vector3     _targetPosition = Vector3.up * 2;   // ������ ��ġ

    private float       _targetRadius = 0.8f;               // ������ ������
    private float       _pinLength = 1.5f;                  // �� ���� ����
    private float       _bottomAngle = 270.0f;              // ���� ���� ���콺 Ŭ������ ��ġ�Ǵ� ���� ����

    private List<PinController> _throwAblePins;             // �ϴܿ� �����Ǵ� �������� ������Ʈ ����Ʈ
    private UI_TargetText       _targetTextUI;

    public void SetUp(GameObject target, GameObject targetTextUI)
    {
        _targetObject = target;
        _targetTransfrom = _targetObject.transform;
        _targetTextUI = targetTextUI.GetComponent<UI_TargetText>();

        _throwAblePins = new List<PinController>();
    }

    private void Update()
    {
        if (Managers.Stage.IsGameOver) return;

        if (Input.GetMouseButtonDown(0) && _throwAblePins.Count > 0)
        {
            // thorwalbePins ����Ʈ�� ����� ù ��° ���� ���ῡ ��ġ
            SetInPinStuckToTarget(_throwAblePins[0].gameObject, _bottomAngle);

            // ���ῡ ��ġ�� ù��° �� ��Ҹ� ����Ʈ���� ����
            _throwAblePins.RemoveAt(0);

            for (int i = 0; i < _throwAblePins.Count; ++i)
            {
                _throwAblePins[i].MoveOneStep(Managers.Stage._pinDistance);
            }
        }

        if (_throwAblePins.Count == 0)
        {
            Managers.Stage.OnClearEvent.Invoke(true);
        }
    }


    private void SetInPinStuckToTarget(GameObject pin, float angle)
    {
        // Ÿ���� �ش� ������ �ɿ� ������ �� ��ġ
        pin.transform.position = Util.GetPositionFromAngle(_targetRadius + _pinLength, angle) + _targetPosition;

        // pin.transform.position += new Vector3(0, 2, 0);
        // �� ������Ʈ ȸ�� ����
        pin.transform.rotation = Quaternion.Euler(0, 0, angle);

        // ���� ���ῡ ��ġ�Ǿ��� �� ����
        pin.GetComponent<PinController>().SetInPinStuckToTarget();

        // �� ������Ʈ�� target�� �ڽ����� �����ؼ� target�� ���� ȸ���ϵ��� �Ѵ�.
        pin.transform.SetParent(_targetTransfrom);
    }

    public void SpawnStuckPin(float angle, int index)
    {
        GameObject pinObject = Managers.Game.Spawn(Define.WorldObject.Pin, "Pin/Pin");

        PinController pin = pinObject.GetComponent<PinController>();

        SetInPinStuckToTarget(pinObject, angle);

        _targetTextUI.SpawnTextIndexUI(true, index, pinObject.transform);
    }

    public void SpawnThrowAlbePin(Vector3 pos, int index)
    {
        GameObject pinObject = Managers.Game.Spawn(Define.WorldObject.Pin, "Pin/Pin");
        pinObject.transform.position = pos;
        
        // Pin ������Ʈ ������ ���� SetUp() �޼ҵ� ȣ��
        PinController pin = pinObject.GetComponent<PinController>();
        _throwAblePins.Add(pin);

        _targetTextUI.SpawnTextIndexUI(true, index, pinObject.transform);
    }
}

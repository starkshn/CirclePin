using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [Header("common")]
    private GameObject  _pin;
    private GameObject  _targetObject;

    private Transform   _targetTransfrom;                     // 과녁 오브젝트의 Transform
    private Vector3     _targetPosition = Vector3.up * 2;     // 과녁의 위치

    private float       _targetRadius = 0.8f;                 // 과녁의 반지름
    private float       _pinLength = 1.5f;                    // 핀 막대 길이
    private float       _bottomAngle = 270.0f;                // 게임 도중 마우스 클릭으로 배치되는 핀의 각도

    private List<PinController> _throwAblePins;         // 하단에 생성되는 던져야할 오브젝트 리스트
    private StageController     _stageController;
    private UI_TargetText       _targetTextUI;

    private StageController _stage;

    private void Start()
    { 
        _targetObject = GameObject.FindGameObjectWithTag("Target");

        _targetTransfrom = _targetObject.transform;

        _targetTextUI = GameObject.FindGameObjectWithTag("TargetTextUI").GetComponent<UI_TargetText>();
    }

    private void Update()
    {
        if (_stage.IsGameOver) return;

        if (Input.GetMouseButtonDown(0) && _throwAblePins.Count > 0)
        {
            // thorwalbePins 리스트에 저장된 첫 번째 핀을 과녁에 배치
            SetInPinStuckToTarget(_throwAblePins[0].gameObject, _bottomAngle);

            // 과녁에 배치한 첫번째 핀 요소를 리스트에서 삭제
            _throwAblePins.RemoveAt(0);

            for (int i = 0; i < _throwAblePins.Count; ++i)
            {
                _throwAblePins[i].MoveOneStep(_stageController._pinDistance);
            }
        }
    }

    public void SetUp(StageController s)
    {
        _throwAblePins = new List<PinController>();
        _stageController = GameObject.FindGameObjectWithTag("StageController").GetComponent<StageController>();
        _stage = s;
    }

    private void SetInPinStuckToTarget(GameObject pin, float angle)
    {
        // 타겟의 해당 각도에 핀에 꽃혔을 때 위치
        pin.transform.position = Util.GetPositionFromAngle(_targetRadius + _pinLength, angle) + _targetPosition;

        // pin.transform.position += new Vector3(0, 2, 0);
        // 핀 오브젝트 회전 설정
        pin.transform.rotation = Quaternion.Euler(0, 0, angle);

        // 핀이 과녁에 배치되었을 때 설정
        pin.GetComponent<PinController>().SetInPinStuckToTarget();

        // 핀 오브젝트를 target의 자식으로 설정해서 target과 같이 회전하도록 한다.
        pin.transform.SetParent(_targetTransfrom);
    }

    public void SpawnStuckPin(float angle, int index)
    {
        GameObject pinObject = Managers.Game.Spawn(Define.WorldObject.Pin, "Pin/Pin");

        PinController pin = pinObject.GetComponent<PinController>();

        SetInPinStuckToTarget(pinObject, angle);

        pin._stage = this._stage;

        _targetTextUI.OnSpawnTextIndexUI.Invoke(true, index, pinObject.transform);
    }

    public void SpawnThrowAlbePin(Vector3 pos, int index)
    {
        GameObject pinObject = Managers.Game.Spawn(Define.WorldObject.Pin, "Pin/Pin");
        pinObject.transform.position = pos;
        
        // Pin 컴포넌트 정보를 얻어와 SetUp() 메소드 호출
        PinController pin = pinObject.GetComponent<PinController>();
        pin._stage = this._stage;
        
        _throwAblePins.Add(pin);

        _targetTextUI.OnSpawnTextIndexUI.Invoke(true, index, pinObject.transform);
    }
}

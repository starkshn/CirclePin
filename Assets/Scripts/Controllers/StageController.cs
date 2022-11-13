using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    // 핀 생성을 위한 pinspawner 컴포넌트
    [SerializeField]
    private GameObject  p_pinSpawner;
    private PinSpawner _pinSpawner;
    
    private uint _stuckPinCount = 5; // 스테이지 시작시 과녁에 고정되어 있는 핀 갯수

    private int _throwablePinCount = 10; // 현재 스테이지를 클리어하기 위해 던져야 하는 핀 갯수

    // 게임화면 하단에 배치되는 던져야 하는 핀들의 첫번째 핀 위치
    private Vector3 _firstPinPosition = Vector3.down * 2;

    public float _pinDistance { private set; get; } = 1;

    private void Start()
    {
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
        else
        {
            Debug.Log("StageController Error!");
        }
    }
}

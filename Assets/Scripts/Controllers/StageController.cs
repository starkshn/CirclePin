using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    // �� ������ ���� pinspawner ������Ʈ
    [SerializeField]
    private GameObject  p_pinSpawner;
    private PinSpawner _pinSpawner;
    
    private uint _stuckPinCount = 5; // �������� ���۽� ���ῡ �����Ǿ� �ִ� �� ����

    private int _throwablePinCount = 10; // ���� ���������� Ŭ�����ϱ� ���� ������ �ϴ� �� ����

    // ����ȭ�� �ϴܿ� ��ġ�Ǵ� ������ �ϴ� �ɵ��� ù��° �� ��ġ
    private Vector3 _firstPinPosition = Vector3.down * 2;

    public float _pinDistance { private set; get; } = 1;

    private void Start()
    {
        p_pinSpawner = GameObject.FindGameObjectWithTag("PinSpawner");
        
        if (p_pinSpawner != null)
        {
            _pinSpawner = p_pinSpawner.GetComponent<PinSpawner>();
            _pinSpawner.SetUp();


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
        else
        {
            Debug.Log("StageController Error!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PinSpawner : MonoBehaviour
{
    private GameObject          _pin;                               // pin Object
    private GameObject          _targetObject;                      // target Object
    private GameObject          _pins;
    private GameObject          _sg;
    private StageController     _sgc;                               // StageController

    private Transform           _targetTransfrom;                   // ���� ������Ʈ�� Transform
    private Vector3             _targetPosition = Vector3.up * 2;   // ������ ��ġ

    private float               _targetRadius = 0.8f;               // ������ ������
    private float               _pinLength = 1.5f;                  // �� ���� ����
    private float               _bottomAngle = 270.0f;              // ���� ���� ���콺 Ŭ������ ��ġ�Ǵ� ���� ����

    private List<PinController> _throwAblePins;                     // �ϴܿ� �����Ǵ� �������� ������Ʈ ����Ʈ
    public  int                 _thowAblePinCount;
    private UI_TargetText       _targetTextUI;


    // Taest Knife
    private List<KnifeController>   _throwAbleKnife;
    private int                     _thowAbleKnifeCount;
    private GameObject              _knife;

    // GearMenu Click
    private bool                _clickedGearMenu = false;

    private void Awake()
    {
        Managers.UI.OnClickedGearMenuButton -= OnClickedGearMenuButton;
        Managers.UI.OnClickedGearMenuButton += OnClickedGearMenuButton;
    }

    public void SetUp(GameObject target, GameObject targetTextUI, GameObject SG)
    {
        _sg = SG;
        _sgc = _sg.GetComponent<StageController>();

        //_pins = GameObject.Find("Pins");
        //if (_pins == null)
        //{
        //    _pins = new GameObject { name = "Pins" };
        //}

        _knife = GameObject.Find("Knife");
        if (_knife == null)
        {
            _knife = new GameObject { name = "Knife" };
        }

        _targetObject = target;
        _targetTransfrom = _targetObject.transform;
        _targetTextUI = targetTextUI.GetComponent<UI_TargetText>();

        // _throwAblePins = new List<PinController>();
        _throwAbleKnife = new List<KnifeController>();
    }

    private void Update()
    {
        if (_sgc.IsGameOver) return;

        //if (!_clickedGearMenu && Input.GetMouseButtonDown(0) && _throwAblePins.Count > 0)
        //{ 
        //    // UIŬ���� true, UIŬ���� �ƴϸ� false��ȯ
        //    if (!EventSystem.current.IsPointerOverGameObject())
        //    {
        //        // StartCoroutine("ThrowPin");
        //        Managers.Sound.Play("Effect/Knife/Throw_Knife", Define.Sound.Effect);

        //        // thorwalbePins ����Ʈ�� ����� ù ��° ���� ���ῡ ��ġ
        //        SetInPinStuckToTarget(_throwAblePins[0].gameObject, _bottomAngle);

        //        // ���ῡ ��ġ�� ù��° �� ��Ҹ� ����Ʈ���� ����
        //        _throwAblePins.RemoveAt(0);

        //        for (int i = 0; i < _throwAblePins.Count; ++i)
        //        {
        //            _throwAblePins[i].MoveOneStep(_sgc._pinDistance);
        //        }

        //        DecreaseThrowableCount();
        //    }
            
        //}

        if (!_clickedGearMenu && Input.GetMouseButtonDown(0) && _throwAbleKnife.Count > 0)
        {
            // UIŬ���� true, UIŬ���� �ƴϸ� false��ȯ
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                // StartCoroutine("ThrowPin");
                Managers.Sound.Play("Effect/Knife/Throw_Knife", Define.Sound.Effect);

                // thorwalbePins ����Ʈ�� ����� ù ��° ���� ���ῡ ��ġ
                // SetInPinStuckToTarget(_throwAbleKnif[0].gameObject, _bottomAngle);

                _throwAbleKnife[0].OnMove = true;

                // ���ῡ ��ġ�� ù��° �� ��Ҹ� ����Ʈ���� ����
                // Į���� �ε����� ���� �ϴ� ����.
                _throwAbleKnife.RemoveAt(0);

                for (int i = 0; i < _throwAbleKnife.Count; ++i)
                {
                    _throwAbleKnife[i].MoveOneStep(_sgc._pinDistance);
                }

                DecreaseThrowableCount();
            }
        }
    }

    public void DecreaseThrowableCount()
    {
        // --_thowAblePinCount;
        --_thowAbleKnifeCount;

        //if (_thowAblePinCount == 0)
        //{
        //    _sgc.GameClear();
        //}

        if (_thowAbleKnifeCount == 0)
        {
            _sgc.GameClear();
        }
    }

    private void SetInPinStuckToTarget(GameObject pin, float angle)
    {
        //// Ÿ���� �ش� ������ �ɿ� ������ �� ��ġ
        //pin.transform.position = Util.GetPositionFromAngle(_targetRadius + _pinLength, angle) + _targetPosition;

        //// pin.transform.position += new Vector3(0, 2, 0);
        //// �� ������Ʈ ȸ�� ����
        //pin.transform.rotation = Quaternion.Euler(0, 0, angle);

        //// ���� ���ῡ ��ġ�Ǿ��� �� ����
        //pin.GetComponent<PinController>().SetInPinStuckToTarget();

        //// �� ������Ʈ�� target�� �ڽ����� �����ؼ� target�� ���� ȸ���ϵ��� �Ѵ�.
        //pin.transform.SetParent(_targetTransfrom);


        // ================================================================================================================
        pin.transform.position = Util.GetPositionFromAngle(_targetRadius + _pinLength, angle) + _targetPosition;
        pin.transform.rotation = Quaternion.Euler(0, 0, angle);
        pin.GetComponent<KnifeController>().SetInPinStuckToTarget();
        pin.transform.SetParent(_targetTransfrom);
    }

    public void SpawnStuckPin(float angle, int index)
    {
        //GameObject pinObject = Managers.Game.Spawn(Define.WorldObject.Pin, "Pin/Pin");
        //PinController pin = pinObject.GetComponent<PinController>();
        //SetInPinStuckToTarget(pinObject, angle);
        //_targetTextUI.SpawnTextIndexUI(true, index, pinObject.transform);

        GameObject knifeObject = Managers.Game.Spawn(Define.WorldObject.DefaultKnife, "Knife/DefaultKnife");
        KnifeController pin = knifeObject.GetComponent<KnifeController>();
        SetInPinStuckToTarget(knifeObject, angle);
        _targetTextUI.SpawnTextIndexUI(true, index, knifeObject.transform);
    }

    public void SpawnThrowAlbePin(Vector3 pos, int index)
    {
        //if (_pins != null)
        //{
        //    GameObject pinObject = Managers.Game.Spawn(Define.WorldObject.Pin, "Pin/Pin");
        //    pinObject.transform.position = pos;
        //    pinObject.transform.SetParent(_pins.transform);

        //    // Pin ������Ʈ ������ ���� SetUp() �޼ҵ� ȣ��
        //    PinController pin = pinObject.GetComponent<PinController>();
        //    _throwAblePins.Add(pin);
        //    ++_thowAblePinCount;

        //    _targetTextUI.SpawnTextIndexUI(true, index, pinObject.transform);
        //}

        if (_knife != null)
        {
            GameObject knifeObect = Managers.Game.Spawn(Define.WorldObject.DefaultKnife, "Knife/DefaultKnife");
            knifeObect.transform.position = pos;
            knifeObect.transform.SetParent(knifeObect.transform);

            KnifeController knifeC = knifeObect.GetComponent<KnifeController>();
            _throwAbleKnife.Add(knifeC);
            ++_thowAbleKnifeCount;

            _targetTextUI.SpawnTextIndexUI(true, index, knifeObect.transform);
        }
    }

    private void OnClickedGearMenuButton(bool clicked)
    {
        if (clicked == true)
            _clickedGearMenu = clicked;
        else
            _clickedGearMenu = clicked;
    }
}

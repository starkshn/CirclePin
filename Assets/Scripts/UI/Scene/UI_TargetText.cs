using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro; // TextMeshPro ����� ���� ��

public class UI_TargetText : UI_Scene
{
    // ============================================
    // For MoveUI Canvas
    // ============================================
    private Canvas          _gameSceneCanvas;
    private RectTransform   _gameSceneCanvasRect;

    // ============================================
    // AD
    // GoogleMobileAdsDemoScript _ad;
    // ============================================

    // ============================================
    // Index UI
    // ============================================
    private Vector3         _distance = Vector3.zero;
    private Transform       _targetTransform;
    private RectTransform   _rectTransform;

    private GameObject      _textPinIndexPrefab;    // �ɿ� ���ڸ� ǥ���ϴ� Text UI
    private Transform       _textParent;            // �� Text�� ��ġ�Ǵ� Panel Transform

    public override void Init()
    {
        base.Init();

        _gameSceneCanvas = GetComponent<Canvas>();
        _gameSceneCanvasRect = _gameSceneCanvas.GetComponent<RectTransform>();

        // ���� �ٴ� �κ�
        // _ad = new GoogleMobileAdsDemoScript();

        // ====================================================
        // ReStaratButton ��ư Extension �������� ���� ��� ����
        // GetButton((int)Define.GameScene_UI_Buttons.ReStartButton).gameObject.BindEvent(OnClickedReStartButton, Define.UIEvent.Click);
        // ====================================================
    }


    // ======================================================
    // Action�޴� �Լ� ����
    //private void OnClickedStartButton(PointerEventData data)
    //{
    //    Managers.Sound.Play("UI/Pop_3");
    //}
    // ======================================================

    public void SetUp(GameObject target)
    {
        // UI�� �i�� �ٴ� ��� ����
        _targetTransform = target.GetComponent<Transform>();
        _textParent = _targetTransform;

        if (_targetTransform != null)
        {
            _rectTransform = Util.FindChild(gameObject, "TargetUIPos").GetComponent<RectTransform>();

            Vector3 screenPos = Camera.main.WorldToScreenPoint(_targetTransform.position);
            _rectTransform.position = screenPos;
        }

        // RectTransform ������Ʈ ���� ������
        _rectTransform = target.GetComponent<RectTransform>();
    }

    public void SpawnTextIndexUI(bool spawn, int index, Transform target)
    {
        if (spawn)
        {
            GameObject textPinIndex = Managers.Game.Spawn(Define.WorldObject.TextPinIndex, "UI/Scene/GameScene/TextPinIndex/TextPinIndex", gameObject.transform);

            // ������������ �ٲ� ũ�⸦ �ٽ� 1, 1, 1�� ����
            textPinIndex.transform.localScale = Vector3.one;

            textPinIndex.GetComponent<Text>().text= index.ToString();
            textPinIndex.GetComponent<WorldToScreenPosition>().SetUp(target);
        }
    }
}

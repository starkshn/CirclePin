using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro; // TextMeshPro 사용을 위한 것

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

    private GameObject      _textPinIndexPrefab;    // 핀에 숫자를 표시하는 Text UI
    private Transform       _textParent;            // 핀 Text가 배치되는 Panel Transform

    public override void Init()
    {
        base.Init();

        _gameSceneCanvas = GetComponent<Canvas>();
        _gameSceneCanvasRect = _gameSceneCanvas.GetComponent<RectTransform>();

        // 광고 다는 부분
        // _ad = new GoogleMobileAdsDemoScript();

        // ====================================================
        // ReStaratButton 버튼 Extension 문법으로 묶는 방법 예시
        // GetButton((int)Define.GameScene_UI_Buttons.ReStartButton).gameObject.BindEvent(OnClickedReStartButton, Define.UIEvent.Click);
        // ====================================================
    }


    // ======================================================
    // Action받는 함수 예시
    //private void OnClickedStartButton(PointerEventData data)
    //{
    //    Managers.Sound.Play("UI/Pop_3");
    //}
    // ======================================================

    public void SetUp(GameObject target)
    {
        // UI가 쫒아 다닐 대상 설정
        _targetTransform = target.GetComponent<Transform>();
        _textParent = _targetTransform;

        if (_targetTransform != null)
        {
            _rectTransform = Util.FindChild(gameObject, "TargetUIPos").GetComponent<RectTransform>();

            Vector3 screenPos = Camera.main.WorldToScreenPoint(_targetTransform.position);
            _rectTransform.position = screenPos;
        }

        // RectTransform 컴포넌트 정보 얻어오기
        _rectTransform = target.GetComponent<RectTransform>();
    }

    public void SpawnTextIndexUI(bool spawn, int index, Transform target)
    {
        if (spawn)
        {
            GameObject textPinIndex = Managers.Game.Spawn(Define.WorldObject.TextPinIndex, "UI/Scene/GameScene/TextPinIndex/TextPinIndex", gameObject.transform);

            // 계층설정으로 바뀐 크기를 다시 1, 1, 1로 변경
            textPinIndex.transform.localScale = Vector3.one;

            textPinIndex.GetComponent<Text>().text= index.ToString();
            textPinIndex.GetComponent<WorldToScreenPosition>().SetUp(target);
        }
    }
}

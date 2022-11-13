using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// World -> Screen Position 클래스
public class WorldToScreenPosition : MonoBehaviour
{
    // 목표 위치로부터 일정거리 떨어져서 배치 될 예정
    private Vector3         _distance = Vector3.zero;
    private Transform       _targetTransform;
    private RectTransform   _rectTransform;

    public void SetUp(Transform target)
    {
        // UI가 쫒아 다닐 대상 설정
        _targetTransform = target;

        // RectTransform 컴포넌트 정보 얻어오기
        _rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        // 화면에 target이 보이지 않으면 UI삭제
        if (_targetTransform == null)
        {
            Managers.Game.Despawn(gameObject);
            return;
        }

        // 오브젝트의 월드 좌표를 기준으로 화면에서의 좌표 값을 구함.
        Vector3 screenPosition = Util.WorldToScreen(_targetTransform.position);

        // 화면 내에서 좌표 + distance 만큼 떨어진 위치를 UI의 위치로 설정
        _rectTransform.position = screenPosition + _distance;
    }
}

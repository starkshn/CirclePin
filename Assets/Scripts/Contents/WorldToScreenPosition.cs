using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// World -> Screen Position Ŭ����
public class WorldToScreenPosition : MonoBehaviour
{
    // ��ǥ ��ġ�κ��� �����Ÿ� �������� ��ġ �� ����
    private Vector3         _distance = Vector3.zero;
    private Transform       _targetTransform;
    private RectTransform   _rectTransform;

    public void SetUp(Transform target)
    {
        // UI�� �i�� �ٴ� ��� ����
        _targetTransform = target;

        // RectTransform ������Ʈ ���� ������
        _rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        // ȭ�鿡 target�� ������ ������ UI����
        if (_targetTransform == null)
        {
            Managers.Game.Despawn(gameObject);
            return;
        }

        // ������Ʈ�� ���� ��ǥ�� �������� ȭ�鿡���� ��ǥ ���� ����.
        Vector3 screenPosition = Util.WorldToScreen(_targetTransform.position);

        // ȭ�� ������ ��ǥ + distance ��ŭ ������ ��ġ�� UI�� ��ġ�� ����
        _rectTransform.position = screenPosition + _distance;
    }
}

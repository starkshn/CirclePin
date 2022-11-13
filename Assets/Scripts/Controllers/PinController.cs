using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : CreatureController
{
    [SerializeField]
    private GameObject _square; // ���� ���� �κ�.
    private float _moveTime = 0.2f;

    protected override void Init()
    {
        _objectType = Define.WorldObject.Pin;
    }

    public void SetInPinStuckToTarget()
    {
        // Throwable Pin���� ���Ǵ� ���� ��� �����̰� ���� ���� �ֱ� ������ �̵� ����
        StopCoroutine("MoveTo");

        _square.SetActive(true);
    }

    public void MoveOneStep(float moveDis)
    {
        StartCoroutine(MoveTo(moveDis));
    }

    private IEnumerator MoveTo(float moveDis)
    {
        Vector3 start = this.transform.position;
        Vector3 end = this.transform.position + Vector3.up * moveDis;

        float cur = 0;
        float percent = 0;

        while (percent < 1)
        {
            cur += Time.deltaTime;
            percent = cur / _moveTime;

            transform.position = Vector3.Lerp(start, end, percent);

            yield return null;
        }
    }
}

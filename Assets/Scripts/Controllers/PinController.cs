using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : CreatureController
{
    [SerializeField]
    private GameObject  _square;            // 핀의 막대 부분.
    private float       _moveTime = 0.2f;
    private GameObject  _sg;

    StageController     _sgc;

    protected override void Init()
    {
        _objectType = Define.WorldObject.Pin;

        _sg = GameObject.FindGameObjectWithTag("StageController");
        _sgc = _sg.GetComponent<StageController>();
    }

    public void SetInPinStuckToTarget()
    {
        // Throwable Pin으로 사용되던 핀의 경우 움직이고 있을 수도 있기 때문에 이동 중지
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Pin"))
        {
            transform.ScaleTween(new Vector2(1.2f, 1.2f), 0.3f);
            Debug.Log("OnTriggerEnter2D Pin");
            
            Managers.Game.Spawn(Define.WorldObject.PinEffect, "Effect/PinEffect", transform);

            _sgc.GameOver();
        }
    }
}

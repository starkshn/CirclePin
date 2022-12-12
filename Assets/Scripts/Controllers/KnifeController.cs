using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeController : CreatureController
{
    private float _moveTime = 0.2f;
    private GameObject _sg;
    private StageController _sgc;

    private Vector3 _moveDir = Vector3.up;
    private float _moveSpeed = 2.0f;
    private bool _move = false;
    public bool OnMove
    {
        get { return _move; }
        set { _move = value; }
    }

    protected override void Init()
    {
        base.Init();

        _objectType = Define.WorldObject.DefaultKnife;

        _sg = GameObject.FindGameObjectWithTag("StageController");
        _sgc = _sg.GetComponent<StageController>();
    }

    private void Update()
    {
        if (_move)
        {
            gameObject.transform.position += _moveDir * _moveSpeed * Time.deltaTime;
        }
    }

    public void SetInPinStuckToTarget()
    {
        // Throwable Pin으로 사용되던 핀의 경우 움직이고 있을 수도 있기 때문에 이동 중지
        StopCoroutine("MoveTo");
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
        if (collision.tag.Equals("Knife"))
        {
            transform.ScaleTween(new Vector2(1.2f, 1.2f), 0.3f);
            Debug.Log("GameOver");

            _sgc.GameOver();   
        }
        
        if (collision.tag.Equals("Target"))
        {
            Debug.Log("Collision Enter to Target!");
            
        }
    }
}
